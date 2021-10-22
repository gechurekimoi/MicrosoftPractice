using System;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string test = "{[]}";
            Console.WriteLine(IsValid(test));
        }


        public static bool IsValid(string s)
        {
            var arr = s.ToCharArray();

            System.Collections.Generic.Dictionary<char, char> dictionary = new System.Collections.Generic.Dictionary<char, char>();

            dictionary.Add('(', ')');
            dictionary.Add('{', '}');
            dictionary.Add('[', ']');

            System.Collections.Generic.Stack<char> stack = new System.Collections.Generic.Stack<char>();

            for (int i = 0; i < arr.Length; i++)
            {
                if(i==0 || stack.Count == 0)
                {
                    stack.Push(arr[i]);
                }
                else
                {
                    char topElement = stack.Peek();

                    if(dictionary.ContainsKey(topElement) && dictionary[topElement] == arr[i])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
            }

            bool IsValid = true;

            if(stack.Count == 0)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }

            return IsValid;
        }
    }
}
