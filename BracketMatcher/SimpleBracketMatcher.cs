using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BracketMatcher
{
    public class SimpleBracketMatcher
    {
        private static IEnumerable<string> _matchedBrackets = new List<string> {"{}", "[]", "()"};
        private static IEnumerable<char> _openBrackets = new List<char> {'{', '[','('};
        private static IEnumerable<char> _closeBrackets = new List<char> {'}',']',')'};
        public List<char> _brackets = new List<char>();

        public SimpleBracketMatcher(string str)
        {
            _brackets.AddRange(str);
        }

        public bool IsOpenBracket(int index)
        {
            return _openBrackets.Any(c => c.Equals(_brackets[index]));
        }

        public bool IsCloseBracket(int index)
        {
            return _closeBrackets.Any(c => c.Equals(_brackets[index]));
        }

        public bool IsMatch(int openBracketIndex, int closeBracketIndex)
        {
            var bracketString = string.Format("{0}{1}",GetBracket(openBracketIndex),_brackets[closeBracketIndex]);
            return _matchedBrackets.Any(b => b.Equals(bracketString));
        }

        private char GetBracket(int index)
        {
            return _brackets[index];
        }

        public int BracketsCount()
        {
            return _brackets.Count;
        }

    }
}