// Copyright 2013-2015 Serilog Contributors
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Parsing
{
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
            if (messageTemplate == null) throw new ArgumentNullException(nameof(messageTemplate));

            var tokens = Tokenize(messageTemplate).ToArray();
            return new MessageTemplate(messageTemplate, tokens);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IEnumerable<MessageTemplateToken> Tokenize(string messageTemplate)
        {
            var messageMemory = messageTemplate.AsMemory();
            if (messageMemory.Length == 0)
            {
                yield return new TextToken("", 0);
                yield break;
            }

            var nextIndex = 0;
            while (true)
            {
                var beforeText = nextIndex;
                var tt = ParseTextToken(nextIndex, messageMemory.Span, out nextIndex);
                if (nextIndex > beforeText)
                    yield return tt;

                if (nextIndex == messageMemory.Length)
                    yield break;

                var beforeProp = nextIndex;
                var pt = ParsePropertyToken(nextIndex, messageMemory.Span, out nextIndex);
                if (beforeProp < nextIndex)
                    yield return pt;

                if (nextIndex == messageMemory.Length)
                    yield break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MessageTemplateToken ParsePropertyToken(int startAt, ReadOnlySpan<char> messageTemplate, out int next)
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

            string propertyNameAndDestructuring, format, alignment;
            if (!TrySplitTagContent(tagContent, out propertyNameAndDestructuring, out format, out alignment))
                return new TextToken(rawText.ToString(), first);

            var propertyName = propertyNameAndDestructuring;
            var destructuring = Destructuring.Default;
            if (propertyName.Length != 0 && TryGetDestructuringHint(propertyName[0], out destructuring))
                propertyName = propertyName.Substring(1);

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

                var width = 0;
                if (!int.TryParse(lastDash == -1 ? alignment : alignment.Substring(1), out width) || width == 0)
                    return new TextToken(rawText.ToString(), first);

                var direction = lastDash == -1 ?
                    AlignmentDirection.Right :
                    AlignmentDirection.Left;

                alignmentValue = new Alignment(direction, width);
            }

            return new PropertyToken(
                propertyName,
                rawText.ToString(),
                format,
                alignmentValue,
                destructuring,
                first);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySplitTagContent(ReadOnlySpan<char> tagContent, out string propertyNameAndDestructuring, out string format, out string alignment)
        {
            var formatDelim = tagContent.IndexOf(':');
            var alignmentDelim = tagContent.IndexOf(',');
            if (formatDelim == -1 && alignmentDelim == -1)
            {
                propertyNameAndDestructuring = tagContent.ToString();
                format = null;
                alignment = null;
            }
            else
            {
                if (alignmentDelim == -1 || (formatDelim != -1 && alignmentDelim > formatDelim))
                {
                    propertyNameAndDestructuring = tagContent.Slice(0, formatDelim).ToString();
                    format = formatDelim == tagContent.Length - 1 ?
                        null :
                        tagContent.Slice(formatDelim + 1).ToString();
                    alignment = null;
                }
                else
                {
                    propertyNameAndDestructuring = tagContent.Slice(0, alignmentDelim).ToString();
                    if (formatDelim == -1)
                    {
                        if (alignmentDelim == tagContent.Length - 1)
                        {
                            alignment = format = null;
                            return false;
                        }

                        format = null;
                        alignment = tagContent.Slice(alignmentDelim + 1).ToString();
                    }
                    else
                    {
                        if (alignmentDelim == formatDelim - 1)
                        {
                            alignment = format = null;
                            return false;
                        }

                        alignment = tagContent.Slice(alignmentDelim + 1, formatDelim - alignmentDelim - 1).ToString();
                        format = formatDelim == tagContent.Length - 1 ?
                            null :
                            tagContent.Slice(formatDelim + 1).ToString();
                    }
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInPropertyTag(char c)
        {
            return IsValidInDestructuringHint(c) ||
                IsValidInPropertyName(c) ||
                IsValidInFormat(c) ||
                c == ':';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInPropertyName(char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
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
        static bool IsValidInDestructuringHint(char c)
        {
            return c == '@' ||
                   c == '$';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInAlignment(char c)
        {
            return char.IsDigit(c) ||
                   c == '-';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsValidInFormat(char c)
        {
            return c != '}' &&
                (char.IsLetterOrDigit(c) ||
                 char.IsPunctuation(c) ||
                 c == ' ');
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TextToken ParseTextToken(int startAt, ReadOnlySpan<char> messageTemplate, out int next)
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
            return new TextToken(accum.ToString(), first);
        }
    }
}
