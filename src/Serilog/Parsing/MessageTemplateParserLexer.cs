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
            var results = new List<MessageTemplateToken> ();

            var lastState = States.Text;
            var currentState = States.Text;

            char lastChar = default;
            int lastTokenStartIndex = 0;
            int currentIndex = 0;
            bool nextChatStartANewToken = true;

            var allTextSpan = messageTemplate.AsSpan();
            foreach (var c in allTextSpan)
            {
                switch (c)
                {
                    case '{' when EnumFastHasFlag(currentState, States.PropertyStart) && lastChar == '{': ChangeState(States.Text | States.EscapeOpenBrakets); nextChatStartANewToken = false; break;
                    case '{' when EnumFastHasFlag(currentState, States.Text): ChangeState(States.PropertyStart); nextChatStartANewToken = true; break;

                    case '}' when lastChar == '}': ChangeState(currentState | States.EscapeCloseBrakets); break;
                    case '}' when !EnumFastHasFlag(currentState, States.Text): nextChatStartANewToken = true; ChangeState(currentState | States.PropertyEnd); break;
                }

                //Validate Token
                //		if (currentState.HasFlag(States.PropertyStart))
                //		{
                //			if(!IsValidInPropertyTag(c))
                //			{
                //				ChangeState(currentState | States.Invalid);
                //			}
                //		}

                if (nextChatStartANewToken && lastChar == '{')
                {
                    ProcessLastToken(allTextSpan.Slice(lastTokenStartIndex, currentIndex - lastTokenStartIndex - 1));
                    lastTokenStartIndex = currentIndex - 1;
                    nextChatStartANewToken = false;
                }
                if (nextChatStartANewToken && lastChar == '}')
                {
                    ChangeState(States.Text);
                    nextChatStartANewToken = false;
                }
                if (nextChatStartANewToken && EnumFastHasFlag(currentState, States.PropertyEnd))
                {
                    ChangeState(States.Text);
                    ProcessLastToken(allTextSpan.Slice(lastTokenStartIndex, currentIndex - lastTokenStartIndex + 1));
                    lastTokenStartIndex++;
                    nextChatStartANewToken = false;
                }

                //ProcessLastToken(allTextSpan.Slice(lastTokenStartIndex, currentIndex-lastTokenStartIndex));

                switch (c)
                {
                    case '@' when EnumFastHasFlag(currentState, States.PropertyStart) && lastChar == '{' && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.WithDestructuringDestructure); break;
                    case '@' when EnumFastHasFlag(currentState, States.PropertyStart) && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.Invalid); break;

                    case '$' when EnumFastHasFlag(currentState, States.PropertyStart) && lastChar == '{' && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.WithDestructuringStringify); break;
                    case '$' when EnumFastHasFlag(currentState, States.PropertyStart) && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.Invalid); break;

                    case ',' when EnumFastHasFlag(currentState, States.PropertyStart) && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.WithAlignment); break;
                    case ':' when EnumFastHasFlag(currentState, States.PropertyStart) && !EnumFastHasFlag(currentState, States.PropertyEnd): ChangeState(currentState | States.WithFormat); break;
                }

                lastChar = c;
                currentIndex++;
                //new { Data = c, currentState}.Dump("Debug");
            }

            lastState = currentState;
            ProcessLastToken(allTextSpan.Slice(lastTokenStartIndex, currentIndex - lastTokenStartIndex));

            return results;

            void ChangeState(States newState)
            {
                lastState = currentState;
                currentState = newState;
            }

            string ProcessText(ReadOnlySpan<char> span)
            {
                var str = span.ToString();
                if (EnumFastHasFlag(currentState, States.EscapeOpenBrakets))
                    str = str.Replace("{{", "{");
                if (EnumFastHasFlag(currentState, States.EscapeCloseBrakets))
                    str = str.Replace("}}", "}");
                return str;
            }

            void ProcessLastToken(ReadOnlySpan<char> span)
            {
                if (EnumFastHasFlag(lastState, States.Invalid) || EnumFastHasFlag(lastState, States.Text))
                {
                    results.Add(new TextToken(ProcessText(span), lastTokenStartIndex));

                    lastTokenStartIndex = currentIndex;
                    return;
                }

                if (EnumFastHasFlag(lastState, States.PropertyStart) && EnumFastHasFlag(lastState, States.PropertyEnd))
                {
                    results.Add(new PropertyToken(ProcessText(span), "", null, null, Destructuring.Default, lastTokenStartIndex));

                    lastTokenStartIndex = currentIndex;
                    return;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool EnumFastHasFlag(States @enum, States flag) => ((@enum & flag) == flag);

        [Flags]
        enum States
        {
            Invalid = 1,
            Text = 1 << 1,
            PropertyStart = 1 << 2,
            WithDestructuringDestructure = 1 << 3,
            WithDestructuringStringify = 1 << 4,
            WithAlignment = 1 << 5,
            WithFormat = 1 << 6,
            EscapeOpenBrakets = 1 << 7,
            EscapeCloseBrakets = 1 << 8,
            PropertyEnd = 1 << 9,
        }

    }
}
