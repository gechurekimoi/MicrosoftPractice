using System;

namespace VelocityQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] A = { -1, 1, 3, 3, 3, 2, 3, 2, 1, 0 };
            Console.WriteLine(solution(A));

        }


        static int solution(int[] A)
        {
            if(A.Length < 3)
            {
                return 0;
            }

            //This will store the differences
            int[] differenceArray = new int[A.Length - 1];

            for (int i = 0; i < A.Length; i++)
            {
                //here we calculate the difference velocity and store it in an array for comparison
                if(i == A.Length - 1)
                {
                    //this means its the last element in the array
                    //therefore no other element in front of it for subtraction
                }
                else
                {
                    differenceArray[i] = A[i + 1] - A[i]; 
                }
            }



            //now we have all differences, now its to calculate how many counts we have

            int CountOfStableVelocity = 0;

            for (int i = 0; i < differenceArray.Length; i++)
            {
                int LengthOfPeriod = 0;

                int currentPosition = i;

                int NextPosition = i + 1;

                while(NextPosition < differenceArray.Length)
                {
                    if(differenceArray[currentPosition] == differenceArray[NextPosition])
                    {
                        LengthOfPeriod++;
                    }

                    NextPosition++;
                }

                if(LengthOfPeriod>= 1)
                {
                    CountOfStableVelocity++;
                }
            }

            return CountOfStableVelocity;

        }
    }
}
