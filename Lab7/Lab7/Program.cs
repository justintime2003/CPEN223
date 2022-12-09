//Student name: Justin The
//Student number: 48875413

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab7
{
    public class Program
    {

        static void Main()
        {
            //You could mainly use unit tests for testing.       
        }
    } 
    public class Recursion 
    {
        /// </summary>
        /// <param name="stack">The stack whose reverse we want to obtain. It must not be modified when method returns.</param>
        /// <param name="reversed">A stack containing the reverse of stack. Originally, reversed is an empty stack.</param>
        public static void Reverse(Stack<int> stack, Stack<int> reversed)
        {
            if (stack.Count == 0)
            {
                foreach (int item in reversed)
                {
                    stack.Push(item);
                }
                //Console.WriteLine("Reversed Stack: "); 
                foreach (int item in reversed)
                {
                    Console.WriteLine(item);
                }
                //Console.WriteLine("Original Stack: "); 
                //foreach (int item in stack) 
                //{
                //    Console.WriteLine(item);
                //}
            }
            else
            {
                reversed.Push(stack.Pop());
                Reverse(stack, reversed);
            }

            //// Base case: return if the stack is empty
            //if (stack.Count == 0) return;

            //// Recursive case: pop the top element from the stack and store it in a variable
            //int top = stack.Pop();

            //// Recursively reverse the remaining elements in the stack
            //Reverse(stack, reversed);

            //// Push the top element onto the reversed stack
            //reversed.Push(top);
        }

        /// <summary>
        /// Determines if sub is a subset of set.
        /// </summary>
        /// <param name="sub">A list representing a set of integers. Duplicate elements are allowed. sub may be modified.</param>
        /// <param name="set">A list representing a set of integers. Duplicate elements are allowed.</param>
        /// <returns>True if sub is a subset of set, false otherwise.</returns>
        public static bool IsASubset(List<int> sub, List<int> set)
        {
            if (sub.Count == 0)
            {
                return true;
            }
            if (!set.Contains(sub[0]))
            {
                return false; 
            }
            if (sub.Contains(sub[0])) //removes duplicates in sub
            {
                sub.Remove(sub[sub.IndexOf(sub[0])]);
                return IsASubset(sub, set); 
            }
            else
            {
                set.Remove(set[set.IndexOf(sub[0])]);
                sub.Remove(sub[0]);
                return IsASubset(sub, set); 
            }
        }

        /// <summary>
        /// Finds and returns the binary equivalent of the positive integer num.
        /// </summary>
        /// <param name="num">The integer whose binary equivalent to find. num is greater than 0.</param>
        /// <returns>A string containing the binary equivalent of num.</returns>
        public static string ToBinary(int num)
        {
            if (num == 0) //base case, return nothing 
            {
                return "";
            }
            if (num % 2 == 0) //check if quotient is even
            {
                return ToBinary(num / 2) + "0";
            }
            else
            {
                return ToBinary(num / 2) + "1";
            }
        }
    }
}