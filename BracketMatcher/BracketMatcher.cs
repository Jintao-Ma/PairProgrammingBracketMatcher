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
            var simpleStack = new SimpleStack<int>();
            var simpleBracketMatcher = new SimpleBracketMatcher(str);

            for (int i = 0; i < simpleBracketMatcher.BracketsCount(); i++)
            {
                if (simpleBracketMatcher.IsOpenBracket(i))
                {
                    simpleStack.Push(i);
                }
                else if (simpleBracketMatcher.IsCloseBracket(i))
                {
                    if (simpleStack.Count() == 0)
                    {
                        return i;
                    }

                    if (simpleBracketMatcher.IsMatch((int)simpleStack.Peek(), i))
                    {
                        simpleStack.Pop();
                    }
                    else
                    {
                        return i;
                    }
                }
            }
            if (simpleStack.Count() > 0)
            {
                return (int)simpleStack.Pop();
            }

            return 0;
        }
    }
}
