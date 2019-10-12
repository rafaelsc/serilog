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
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Parsing
{
    /// <summary>
    /// Parses message template strings into sequences of text or property
    /// tokens.
    /// </summary>
    public class MessageTemplateParserLexer : IMessageTemplateParser
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

            var tokens = (messageTemplate.Length == 0) ? new[] { TextToken.Empty } : Tokenize(messageTemplate).ToArray();
            return new MessageTemplate(messageTemplate, tokens);
        }

        static IEnumerable<MessageTemplateToken> Tokenize(string messageTemplate)
        {
            var tokens = new List<MessageTemplateToken>();

            var isAProp = false;
            var enumerator = messageTemplate.AsSpan().Tokenization("{}");
            while (enumerator.MoveNext())
            {
                var a = enumerator.Current;
                var data = a.Data.ToString();

                if (a.IsToken == false)
                {
                    if (isAProp)
                    {
                        tokens.Add( new TextToken(data, 0) );
                    }
                    else
                    {
                        tokens.Add( new PropertyToken(data, data, "", null, Destructuring.Default, a.Index) );
                    }
                }
                else
                {
                    if (a.Data[0] == '{')
                    {
                        isAProp = true;
                    }
                    else if (a.Data[0] == '}')
                    {
                        isAProp = false;
                    }
                }
            }

            return tokens;
        }
    }


    internal static class MemoryExtensions
    {
        public static SpanSplitEnumerator<string> Tokenization(this ReadOnlySpan<char> span, string separator) => new SpanSplitEnumerator<string>(span, separator.AsSpan());
    }

    internal ref struct SpanSplitEnumerator<T> where T : IEquatable<T>
    {
        private readonly ReadOnlySpan<char> _sequence;
        private readonly ReadOnlySpan<char> _separator;
        private int _offset;
        private int _index;
        private bool _lastIsToken;

        public SpanSplitEnumerator<T> GetEnumerator() => this;

        internal SpanSplitEnumerator(ReadOnlySpan<char> span, ReadOnlySpan<char> separator)
        {
            _sequence = span;
            _separator = separator;
            _index = 0;
            _offset = 0;
            _lastIsToken = false;
        }

        public TokenInfo Current => new TokenInfo(_sequence.Slice(_offset, _index), _lastIsToken, _offset);

        public bool MoveNext()
        {
            if (_sequence.Length - _offset < _index) { return false; }
            var slice = _sequence.Slice(_offset += _index);

            if (slice.IsEmpty) { return false; }

            var nextIdx = slice.IndexOfAny<char>(_separator);
            if (nextIdx == 0)
            {
                _index = nextIdx + 1;
                _lastIsToken = true;
            }
            else if (nextIdx != -1)
            {
                _index = nextIdx;
                _lastIsToken = false;
            }
            else
            {
                _index = slice.Length;
                _lastIsToken = false;
            }

            return true;
        }

        internal ref struct TokenInfo
        {
            public ReadOnlySpan<char> Data { get; }
            public bool IsToken { get; }

            public int Index { get; }

            internal TokenInfo(ReadOnlySpan<char> data, bool isToken, int index)
            {
                this.Data = data;
                this.IsToken = isToken;
                this.Index = index;
            }
        }
    }
}
