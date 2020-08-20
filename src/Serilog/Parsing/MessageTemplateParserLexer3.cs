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
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Parsing
{
    /// <summary>
    /// Parses message template strings into sequences of text or property
    /// tokens.
    /// </summary>
    public class MessageTemplateParserLexer3 : IMessageTemplateParser
    {
        /// <summary>
        /// Parse the supplied message template.
        /// </summary>
        /// <param name="messageTemplate">The message template to parse.</param>
        /// <returns>A sequence of text or property tokens. Where the template
        /// is not syntactically valid, text tokens will be returned. The parser
        /// will make a best effort to extract valid property tokens even in the
        /// presence of parsing issues.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="messageTemplate"/> is <code>null</code></exception>
        public MessageTemplate Parse(string messageTemplate)
        {
            if (messageTemplate == null) throw new ArgumentNullException(nameof(messageTemplate));

            return new MessageTemplate(messageTemplate, Parser.Tokenize(messageTemplate));
        }

        ref struct Parser
        {
            public static List<MessageTemplateToken> Tokenize(string template)
            {
                var tokenizer = new Parser(template);
                return tokenizer.Tokenize();
            }

            ReadOnlySpan<char> _source;
            int _currentIndex;

            StringBuilder _literalBuilder;
            StringBuilder _propertyBuilder;
            StringBuilder _argBuilder;

            Parser(string source)
            {
                _source = source.AsSpan();
                _currentIndex = 0;

                _literalBuilder = new StringBuilder();
                _propertyBuilder = new StringBuilder();
                _argBuilder = new StringBuilder();
            }

            private char CurrentChar() => _currentIndex >= _source.Length ? '\0' : _source[_currentIndex];

            private char PullNextChar()
            {
                _currentIndex++;
                return _currentIndex <= _source.Length ? _source[_currentIndex - 1] : '\0';
            }

            private char PeekNextChar() => _currentIndex + 1 < _source.Length ? _source[_currentIndex + 1] : '\0';

            private List<MessageTemplateToken> Tokenize()
            {
                var tokens = new List<MessageTemplateToken>();

                var token = ParseNextToken();
                while (token != null)
                {
                    tokens.Add(token);
                    token = ParseNextToken();
                }

                return tokens;
            }

            private MessageTemplateToken ParseNextToken()
            {
                int initialTokenIndex = _currentIndex;

                var currentChar = CurrentChar();
                if (currentChar == '\0')
                    return null;

                var nextChar = PeekNextChar();
                if (currentChar == '{')
                {
                    if (nextChar != '{')
                    {
                        //PullNextChar();
                        return ParseProperty(initialTokenIndex);
                    }
                }
                if (nextChar == '\0')
                {
                    _currentIndex++;
                    return new TextToken(currentChar.ToString(), initialTokenIndex);
                }
                return ParseLiteral(initialTokenIndex);
            }

            private MessageTemplateToken ParseLiteral(int startIdx)
            {
                _literalBuilder.Clear();

                int i;
                for (i = _currentIndex; i < _source.Length; i++)
                {
                    var curChar = PullNextChar();
                    if (curChar == '\0')
                    {
                        break;
                    }
                    if (curChar == '{')
                    {
                        var nextChar = CurrentChar();
                        if (nextChar == '{')
                        {
                            _literalBuilder.Append('{');
                            PullNextChar();
                            continue;
                        }
                        break;
                    }
                    if (curChar == '}')
                    {
                        var nextChar = CurrentChar();
                        if (nextChar == '}')
                        {
                            _literalBuilder.Append('}');
                            PullNextChar();
                            continue;
                        }
                        break;
                    }
                    _literalBuilder.Append(curChar);
                }

                _currentIndex = i;
                return new TextToken(_literalBuilder.ToString(), startIdx);
            }

            private PropertyToken ParseProperty(int idx)
            {
                _literalBuilder.Clear();
                _propertyBuilder.Clear();
                _argBuilder.Clear();

                var destructuring = Destructuring.Default;

                bool parsingArg = false;

                var currentChar = CurrentChar();
                _literalBuilder.Append(currentChar);
                PullNextChar();

                bool breakLoop = false;
                int i = _currentIndex;

                while (i < _source.Length && !breakLoop)
                {
                    currentChar = PullNextChar();
                    _literalBuilder.Append(currentChar);

                    switch (currentChar)
                    {
                        case '\0':
                        case '}':
                            breakLoop = true;
                            break;
                        case '@':
                            destructuring = Destructuring.Destructure;
                            break;
                        case '$':
                            destructuring = Destructuring.Stringify;
                            break;
                        case ':':
                            parsingArg = true;
                            break;
                        default:
                            if (!parsingArg)
                            {
                                _propertyBuilder.Append(currentChar);
                            }
                            else
                            {
                                _argBuilder.Append(currentChar);
                            }
                            break;
                    }
                    i++;
                }

                _currentIndex = i;

                return new PropertyToken(
                    _propertyBuilder.ToString(),
                    _literalBuilder.ToString(),
                    _argBuilder.ToString(),
                    null,
                    destructuring: destructuring,
                    idx);
            }
        }

    }
}
