using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BracketMatcher
{
    public class BracketMatcher
    {
        List<string> _matchedBrackets = new List<string> { "{}", "[]", "()" };
        List<char> _openBrackets = new List<char> { '{', '[', '(' };
        List<char> _closeBrackets = new List<char> { '}', ']', ')' };

        List<char> _brackets = new List<char>();

        public int Match(string str)
        {
            var bracketStack = new Stack();
            if (str == "")
            {
                return 0;
            }

            if (_matchedBrackets.Contains(str))
            {
                return 0;
            }

            _brackets.AddRange(str);

            for (int i = 0; i < _brackets.Count; i++)
            {
                if (IsOpenBracket(_brackets[i]))
                {
                    bracketStack.Push(i);
                }
                if (IsCloseBracket(_brackets[i]))
                {
                    if (bracketStack.Count == 0)
                    {
                        return i;
                    }

                    var openBracketChar = GetBracket((int)bracketStack.Peek(), _brackets);

                    if (IsMatch(openBracketChar, _brackets[i]))
                    {
                        bracketStack.Pop();
                    }
                    else
                    {
                        return (int)bracketStack.Peek();
                    }
                }
            }
            if (bracketStack.Count > 0)
            {
                return (int)bracketStack.Pop();
            }

            return 0;
        }

        private bool IsOpenBracket(char character)
        {
            return _openBrackets.Any(c => c.Equals(character));
        }

        private bool IsCloseBracket(char character)
        {
            return _closeBrackets.Any(c => c.Equals(character));
        }

        private bool IsMatch(char openBracket, char closeBracket)
        {
            var bracket = new char[] { openBracket, closeBracket };
            var bracketString = new String(bracket);
            return _matchedBrackets.Any(b => b.Equals(bracketString));
        }

        private char GetBracket(int index, List<char> charList)
        {
            return charList[index];
        }
    }
}
