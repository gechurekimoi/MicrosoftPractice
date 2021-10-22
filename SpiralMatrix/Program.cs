using System;
using System.Collections.Generic;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int[][] matrix = new int[3][];

            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5, 6 };
            matrix[2] = new int[] { 7, 8, 9 };

            //matrix[0] = new int[] { 1, 2, 3 ,4 };
            //matrix[1] = new int[] { 5, 6 ,7, 8 };
            //matrix[2] = new int[] { 9, 10, 11, 12 };

            //[[3],[2]]
            //matrix[0] = new int[] { 3 };
            //matrix[1] = new int[] { 2 };

            var list = SpiralOrderNew(matrix);

        }

        public static IList<int> SpiralOrderWorking(int[][] matrix)
        {
            List<int> list = new List<int>();
            int top = 0;
            int left = 0;
            int right = matrix[0].Length - 1;
            int bottom = matrix.Length - 1;

            while (true)
            {
                //Left to Right
                for (int i = left; i <= right; i++)
                {
                    list.Add(matrix[top][i]);
                }
                top++;
                if (left > right || top > bottom) break;

                //Top to Bottom
                for (int i = top; i <= bottom; i++)
                {
                    list.Add(matrix[i][right]);
                }
                right--;
                if (left > right || top > bottom) break;

                //Right to Left
                for (int i = right; i >= left; i--)
                {
                    list.Add(matrix[bottom][i]);
                }
                bottom--;
                if (left > right || top > bottom) break;

                //Bottom to Top
                for (int i = bottom; i >= top; i--)
                {
                    list.Add(matrix[i][left]);
                }
                left++;
                if (left > right || top > bottom) break;
            }//Repeat
            return list;
        }

        public static IList<int> SpiralOrderNew(int[][] matrix)
        {
            if (matrix == null)
                return null;

            IList<int> finalResult = new List<int>();

            if (matrix.Length == 1)
            {
                foreach (var item in matrix[0])
                {
                    finalResult.Add(item);
                }

                return finalResult;
            }



            //get lenghts of array
            int LengthOfOuter = matrix.Length;
            int LengthOfInner = matrix[0].Length;

            //take all elements in first Position of array
            foreach (var item in matrix[0])
            {
                finalResult.Add(item);
            }


            if(LengthOfOuter > 2)
            {
                //Take only last element in middle arrays (right most elements)
                for (int i = 1; i < (LengthOfOuter-1); i++)
                {
                    finalResult.Add(matrix[i][LengthOfInner - 1]);
                }
            }
            

            //take all elements of last array reversed
            for (int j = (LengthOfInner - 1); j > -1; j--)
            {
                finalResult.Add(matrix[LengthOfOuter - 1][j]);
            }




            


            if (LengthOfOuter > 2)
            {
                //Take only first element in middle arrays (left most elements)
                for (int i = (LengthOfOuter - 1); i > 0 ; i--)
                {
                    finalResult.Add(matrix[i][LengthOfInner - 1]);
                }
            }


            ////take remaining elements of middle array except the last and the first
            //for (int i = 1; i < (LengthOfOuter -1); i++)
            //{
            //    for (int j = 0; j < (LengthOfInner - 1); j++)
            //    {
            //        finalResult.Add(matrix[i][j]);
            //    }
            //}

            return finalResult;

        }
    }
}
