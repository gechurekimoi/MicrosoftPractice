using System;
using System.Numerics;

namespace SmallestNumberWithSameNumberOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(solution2(125));
        }

        static BigInteger solution(int N)
        {
            if(N < 10)
            {
                return 0;
            }
            else
            {
                string theNumberString = N.ToString();

                int Length = theNumberString.Length;

                int numberOfZerosNeeded = Length - 1;

                string NewNumber = "1";

                for (int i = 0; i < numberOfZerosNeeded; i++)
                {
                    NewNumber += "0";
                }

                BigInteger result = BigInteger.Parse(NewNumber);

                return result;

            }
        }


        static BigInteger solution2(int N)
        {
            if (N < 10)
            {
                return 0;
            }
            else
            {
                string theNumberString = N.ToString();

                int Length = theNumberString.Length;

                double numberOfZerosNeeded = Convert.ToDouble(Length - 1);

                double result = Math.Pow(10, numberOfZerosNeeded);

                return Convert.ToInt32(result);

            }
        }
    }
}
