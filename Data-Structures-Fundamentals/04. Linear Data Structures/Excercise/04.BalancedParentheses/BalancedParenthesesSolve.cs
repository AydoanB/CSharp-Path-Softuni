using Problem02.DoublyLinkedList;

namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            //var list = new DoublyLinkedList<char>();

            //foreach (var element in parentheses)
            //{
            //    list.AddFirst((char)element);
            //}

            //while (list.Count != 0)
            //{
            //    var firstChar = list.GetFirst();
            //    var lastChar = list.GetLast();

            //    if (Math.Abs(firstChar-lastChar)==1|| Math.Abs(firstChar - lastChar) == 2)
            //    {
            //        list.RemoveFirst();
            //        list.RemoveLast();
            //    }
            //    else
            //    {
            //        break;

            //    }

            //    if (list.Count == 0)
            //    {
            //        return true;
            //    }
            //}

            //return false;
            if (parentheses.Length % 2 == 1)
            {
                return false;
            }
            var stack = new Stack<char>(parentheses.Length / 2);

            foreach (var character in parentheses)
            {
                char expected = default;

                switch (character)
                {
                    case '}':
                        expected = '{';
                        break;
                    case ')':
                        expected = '(';
                        break;
                    case ']':
                        expected = '[';
                        break;
                    default:
                        stack.Push(character);
                        break;
                }

                if (expected == default)
                {
                    continue;
                }

                if (stack.Pop() != expected)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
