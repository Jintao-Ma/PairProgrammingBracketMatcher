using System;
using System.Collections.Generic; 

namespace BracketMatcher
{
    public class SimpleStack<T>
    {
        private T[] _stack;
        private int _stackPointer = 0;
        readonly int _stackSize; 

        public SimpleStack():this(100)
        {}

        public SimpleStack(int size)
        {
            _stackSize = size;
            _stack = new T[_stackSize];
        }

        public void Push(T item)
        {
            if(_stackPointer >= _stackSize)
            {
                throw new StackOverflowException();
            }
            _stack[_stackPointer] = item;
            _stackPointer++;
        }

        public T Pop()
        {
            _stackPointer--;
            if(_stackPointer >= 0)
            {
                return _stack[_stackPointer];
            }
            else
            {   
                _stackPointer = 0;
                throw new InvalidOperationException("Can not pop an empty stack!");
            }
        }

        public T Peek()
        {
            if(_stackPointer > 0)
            {
                return _stack[_stackPointer - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }

        public int Count()
        {
            if(_stackPointer == 0)
            {
                return 0;
            }
            return _stackPointer + 1;
        }
    }
}