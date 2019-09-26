﻿// Copyright 2013-2015 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Parsing
{

#if TRYPARSEWITHSPAN

    /// <summary>
    /// Parses message template strings into sequences of text or property
    /// tokens.
    /// </summary>
    public class MessageTemplateParser : IMessageTemplateParser
    {
        /// <summary>
        /// Parse the supplied message template.
        /// </summary>
        /// <param name="messageTemplate">The message template to parse.</param>
        /// <returns>A sequence of text or property tokens. Where the template
        /// is not syntactically valid, text tokens will be returned. The parser
        /// will make a best effort to extract valid property tokens even in the
        /// presence of parsing issues.</returns>
        public MessageTemplate Parse(string messageTemplate)
        {
            if (messageTemplate == null)
                throw new ArgumentNullException(nameof(messageTemplate));

            return new MessageTemplate(messageTemplate, Tokenize(messageTemplate.AsSpan()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IEnumerable<MessageTemplateToken> Tokenize(in ReadOnlySpan<char> messageTemplate)
        {
            if (messageTemplate.IsEmpty)
                return new[] { new TextToken(string.Empty, 0) };

            var tokens = new List<MessageTemplateToken>();

            var nextIndex = 0;
            while (true)
            {
                var beforeText = nextIndex;
                var tt = ParseTextToken(nextIndex, messageTemplate, out nextIndex);
                if (nextIndex > beforeText)
                    tokens.Add(tt);

                if (nextIndex == messageTemplate.Length)
                    return tokens.ToArray();

                var beforeProp = nextIndex;
                var pt = ParsePropertyToken(nextIndex, messageTemplate, out nextIndex);
                if (beforeProp < nextIndex)
                    tokens.Add(pt);

                if (nextIndex == messageTemplate.Length)
                    return tokens.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MessageTemplateToken ParsePropertyToken(int startAt, in ReadOnlySpan<char> messageTemplate, out int next)
        {
            var first = startAt;
            startAt++;
            while (startAt < messageTemplate.Length && IsValidInPropertyTag(messageTemplate[startAt]))
                startAt++;

            if (startAt == messageTemplate.Length || messageTemplate[startAt] != '}')
            {
                next = startAt;
                return new TextToken(messageTemplate.Slice(first, next - first).ToString(), first);
            }

            next = startAt + 1;

            var rawText = messageTemplate.Slice(first, next - first);
            var tagContent = rawText.Slice(1, next - (first + 2));
            if (tagContent.Length == 0)
                return new TextToken(rawText.ToString(), first);

            if (!TrySplitTagContent(tagContent, out var propertyNameAndDestructuring, out var format, out var alignment))
                return new TextToken(rawText.ToString(), first);

            var propertyName = propertyNameAndDestructuring;
            var destructuring = Destructuring.Default;
            if (propertyName.Length != 0 && TryGetDestructuringHint(propertyName[0], out destructuring))
                propertyName = propertyName.Slice(1);

            if (propertyName.Length == 0)
                return new TextToken(rawText.ToString(), first);

            for (var i = 0; i < propertyName.Length; ++i)
            {
                var c = propertyName[i];
                if (!IsValidInPropertyName(c))
                    return new TextToken(rawText.ToString(), first);
            }

            if (format != null)
            {
                for (var i = 0; i < format.Length; ++i)
                {
                    var c = format[i];
                    if (!IsValidInFormat(c))
                        return new TextToken(rawText.ToString(), first);
                }
            }

            Alignment? alignmentValue = null;
            if (alignment != null)
            {
                for (var i = 0; i < alignment.Length; ++i)
                {
                    var c = alignment[i];
                    if (!IsValidInAlignment(c))
                        return new TextToken(rawText.ToString(), first);
                }

                var lastDash = alignment.LastIndexOf('-');
                if (lastDash > 0)
                    return new TextToken(rawText.ToString(), first);

                if (!int.TryParse(lastDash == -1 ? alignment : alignment.Slice(1), out var width) || width == 0)
                    return new TextToken(rawText.ToString(), first);

                var direction = lastDash == -1 ?
                    AlignmentDirection.Right :
                    AlignmentDirection.Left;

                alignmentValue = new Alignment(direction, width);
            }

            return new PropertyToken(
                propertyName.ToString(),
                rawText.ToString(),
                format.IsEmpty ? null : format.ToString(),
                alignmentValue,
                destructuring,
                first);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySplitTagContent(in ReadOnlySpan<char> tagContent, out ReadOnlySpan<char> propertyNameAndDestructuring, out ReadOnlySpan<char> format, out ReadOnlySpan<char> alignment)
        {
            var formatDelim = tagContent.IndexOf(':');
            var alignmentDelim = tagContent.IndexOf(',');
            if (formatDelim == -1 && alignmentDelim == -1)
            {
                propertyNameAndDestructuring = tagContent;
                format = null;
                alignment = null;
            }
            else
            {
                if (alignmentDelim == -1 || (formatDelim != -1 && alignmentDelim > formatDelim))
                {
                    propertyNameAndDestructuring = tagContent.Slice(0, formatDelim);
                    format = formatDelim == tagContent.Length - 1 ?
                        null :
                        tagContent.Slice(formatDelim + 1);
                    alignment = null;
                }
                else
                {
                    propertyNameAndDestructuring = tagContent.Slice(0, alignmentDelim);
                    if (formatDelim == -1)
                    {
                        if (alignmentDelim == tagContent.Length - 1)
                        {
                            alignment = format = null;
                            return false;
                        }

                        format = null;
                        alignment = tagContent.Slice(alignmentDelim + 1);
                    }
                    else
                    {
                        if (alignmentDelim == formatDelim - 1)
                        {
                            alignment = format = null;
                            return false;
                        }

                        alignment = tagContent.Slice(alignmentDelim + 1, formatDelim - alignmentDelim - 1);
                        format = formatDelim == tagContent.Length - 1 ?
                            null :
                            tagContent.Slice(formatDelim + 1);
                    }
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryGetDestructuringHint(char c, out Destructuring destructuring)
        {
            switch (c)
            {
                case '@':
                    {
                        destructuring = Destructuring.Destructure;
                        return true;
                    }
                case '$':
                    {
                        destructuring = Destructuring.Stringify;
                        return true;
                    }
                default:
                    {
                        destructuring = Destructuring.Default;
                        return false;
                    }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TextToken ParseTextToken(int startAt, in ReadOnlySpan<char> messageTemplate, out int next)
        {
            var first = startAt;

            var accum = new StringBuilder();
            do
            {
                var nc = messageTemplate[startAt];
                if (nc == '{')
                {
                    if (startAt + 1 < messageTemplate.Length &&
                        messageTemplate[startAt + 1] == '{')
                    {
                        accum.Append(nc);
                        startAt++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    accum.Append(nc);
                    if (nc == '}')
                    {
                        if (startAt + 1 < messageTemplate.Length &&
                            messageTemplate[startAt + 1] == '}')
                        {
                            startAt++;
                        }
                    }
                }

                startAt++;
            } while (startAt < messageTemplate.Length);

            next = startAt;

            if (first == next)
                return null;

            return new TextToken(accum.ToString(), first);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInPropertyTag(char c) => c == ':' || IsValidInDestructuringHint(c) || IsValidInPropertyName(c) || IsValidInFormat(c);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInPropertyName(char c) => c == '_' || char.IsLetterOrDigit(c);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInDestructuringHint(char c) => c == '@' || c == '$';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInAlignment(char c) => c == '-' || char.IsDigit(c);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInFormat(char c) => c != '}' && (c == ' ' || char.IsLetterOrDigit(c) || char.IsPunctuation(c));
    }

#endif

}
