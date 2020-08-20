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
    public class MessageTemplateParserLexer2 : IMessageTemplateParser
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

            return new MessageTemplate(messageTemplate, TokenizerX.Parse(messageTemplate));
        }


        /// <summary>
        /// Transforms a template source into a series of tokens.
        /// </summary>
        public class TokenizerX
        {
            /// <summary>
            /// Parses a template source into a series of tokens.
            /// </summary>
            /// <param name="template">The source of the template to parse.</param>
            public static List<MessageTemplateToken> Parse(string template)
            {
                var tokenizer = new TokenizerX(template);
                return tokenizer.Tokenize();
            }

            string _source;
            int _index;

            TokenizerX(string source)
            {
                _source = source;
                _index = 0;
            }

            private List<MessageTemplateToken> Tokenize()
            {
                var tokens = new List<MessageTemplateToken>();
                var token = ParseNext();
                while (token != null)
                {
                    tokens.Add(token);
                    token = ParseNext();
                }
                return tokens;
            }

            private MessageTemplateToken ParseNext()
            {
                int i = _index;
                char curChar = CurrentChar();
                if (curChar == '\0')
                {
                    return null;
                }
                char nextChar = Peek();
                if (curChar == '{')
                {
                    if (nextChar != '{')
                    {
                        Pull();
                        return ParseProperty(i);
                    }
                }
                if (nextChar == '\0')
                {
                    _index++;
                    return new TextToken(curChar.ToString(), i);
                }
                return ParseLiteral(i);
            }

            private MessageTemplateToken ParseLiteral(int startIdx)
            {
                var literalBuilder = new StringBuilder();

                int i;
                for (i = _index; i < _source.Length; i++)
                {
                    char curChar = Pull();
                    if (curChar == '\0')
                    {
                        break;
                    }
                    if (curChar == '{')
                    {
                        char nextChar = CurrentChar();
                        if (nextChar == '{')
                        {
                            literalBuilder.Append('{');
                            Pull();
                            continue;
                        }
                        break;
                    }
                    if (curChar == '}')
                    {
                        char nextChar = CurrentChar();
                        if (nextChar == '}')
                        {
                            literalBuilder.Append('}');
                            Pull();
                            continue;
                        }
                        break;
                    }
                    literalBuilder.Append(curChar);
                }

                _index = i;
                return new TextToken(literalBuilder.ToString(), startIdx);
            }

            private PropertyToken ParseProperty(int idx)
            {
                var propertyBuilder = new StringBuilder();
                var argBuilder = new StringBuilder();
                var destructuring = Destructuring.Default;

                bool parsingArg = false;

                bool breakLoop = false;
                int i = _index;

                while (i < _source.Length && !breakLoop)
                {
                    char curChar = Pull();
                    switch (curChar)
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
                                propertyBuilder.Append(curChar);
                            }
                            else
                            {
                                argBuilder.Append(curChar);
                            }
                            break;
                    }
                    i++;
                }

                _index = i;

                return new PropertyToken(
                    propertyBuilder.ToString(),
                    propertyBuilder.ToString(),
                    argBuilder.ToString(),
                    null,
                    destructuring: destructuring,
                    idx);

                //return token.SetNameAndArg(propertyBuilder.ToString(), argBuilder.ToString());
            }

            char CurrentChar() => _index >= _source.Length ? '\0' : _source[_index];

            char Pull()
            {
                _index++;
                return _index <= _source.Length ? _source[_index - 1] : '\0';
            }

            char Peek() => _index + 1 < _source.Length ? _source[_index + 1] : '\0';
        }
    }
}
