using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveKdigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Console.WriteLine(RemoveKdigits("10001", 4));
            //Console.WriteLine(RemovekDigitsRevised("10001", 4));
            Console.WriteLine(RemovekDigitsRevised("1432219", 3));




        }

        static string RemoveKdigits(string num, int k)
        {
            if (k >= num.Length)
            {
                return "0";
            }

            List<int> newNumbers = new List<int>();


            for (int i = 0; i < num.Length; i++)
            {
                //here we remove the i-th number from the string, this reduces the size of the string
                string newNum = num.Substring(i);

                if (newNum.Length >= k)
                {
                    string remaining = newNum.Substring(k);

                    remaining = num.Substring(0, i) + remaining;

                    newNumbers.Add(Convert.ToInt32(remaining));
                }

            }

            int smallestNumber = newNumbers.OrderBy(p => p).FirstOrDefault();

            return smallestNumber.ToString();

        }


        static string RemovekDigitsRevised(string number, int NoOfRemovedElements)
        {
            if (NoOfRemovedElements >= number.Length)
            {
                return "0";
            }



            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0)
                {
                    stack.Push(Convert.ToInt32(number[i].ToString()));
                }
                else
                {
                    

                    int numberOfElementsRemainingToBeAddedToStack = number.Substring(i).Count();

                    int NumberOfElementsToRemainInString = number.Count() - NoOfRemovedElements;

                    int target = stack.Count + numberOfElementsRemainingToBeAddedToStack;

                    if (target >= NumberOfElementsToRemainInString)
                    {
                        //here it means we can pop elements from stack

                        int topElement = stack.Peek();

                        int currentElement = Convert.ToInt32(number[i].ToString());

                        if (currentElement < topElement)
                        {
                            stack.Pop();

                            stack.Push(currentElement);
                        }
                        else 
                        {
                            stack.Push(currentElement);
                        }

                    }
                    else
                    {
                        //here it means you cannot pop elements from stack
                        stack.Push(Convert.ToInt32(number[i].ToString()));
                    }
                }

               

            }

            string newNumber = "";
            var stackArray = stack.ToArray();
            Array.Reverse(stackArray);



            foreach (var item in stackArray)
            {
                newNumber += item.ToString();
            }

         

            return newNumber;

        }
    }

}
