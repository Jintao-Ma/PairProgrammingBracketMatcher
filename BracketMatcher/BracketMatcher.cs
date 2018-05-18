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

            return MatchBracket(simpleStack,simpleBracketMatcher,0);
        }

        public int MatchBracket(SimpleStack<int> stack, SimpleBracketMatcher bracketString, int index)
        {
            if(index < bracketString.BracketsCount())
            {
                if(!bracketString.IsCloseBracket(index))
                {
                    if(bracketString.IsOpenBracket(index))
                        stack.Push(index);
                    
                    index++;
                    return MatchBracket(stack,bracketString,index);
                }
                else
                {
                    if (stack.Count() == 0 || !bracketString.IsMatch(stack.Peek(), index))
                    {
                        return index;
                    }
                    else
                    {
                        index++;
                        stack.Pop();
                        return MatchBracket(stack,bracketString,index);
                    }
                }
            }
                        
            if (stack.Count() > 0)
            {
                return stack.Pop();
            }
            return 0;
        }
    }
}
