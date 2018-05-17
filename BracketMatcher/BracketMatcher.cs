using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BracketMatcher
{
    public class BracketMatcher
    {
        public int Match(string str)
        {
            var bracketStack = new Stack();
            var simpleBracketMatcher = new SimpleBracketMatcher(str);
            if (str == "")
            {
                return 0;
            }

            for (int i = 0; i < simpleBracketMatcher.Brackets.Count; i++)
            {
                if (simpleBracketMatcher.IsOpenBracket(i))
                {
                    bracketStack.Push(i);
                }
                if (simpleBracketMatcher.IsCloseBracket(i))
                {
                    if (bracketStack.Count == 0)
                    {
                        return i;
                    }

                    if (simpleBracketMatcher.IsMatch((int)bracketStack.Peek(), i))
                    {
                        bracketStack.Pop();
                    }
                    else
                    {
                        return i;
                    }
                }
            }
            if (bracketStack.Count > 0)
            {
                return (int)bracketStack.Pop();
            }

            return 0;
        }
    }
}
