using System;
using System.Linq;

namespace TwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] arr = { 3, 3 };

            var result = TwoSum(arr, 6);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static int[] TwoSum(int[] nums, int target)
        {
            int[] result = { 0, 0};


            for (int i = 0; i < nums.Length; i++)
            {
                int currentValue = nums[i];

                int secondValue = target - currentValue;

                if(currentValue != secondValue)
                {
                    if ((Array.IndexOf(nums, secondValue)) != -1)
                    {
                        result[0] = i;
                        result[1] = Array.IndexOf(nums, secondValue);
                        break;
                    }
                }
                else
                {
                    int countSameElement = nums.Where(p => p == secondValue).Count();

                    if(countSameElement > 1)
                    {
                        for (int j = 0; j < nums.Length; j++)
                        {
                            if(nums[j] == secondValue)
                            {
                                if (j != i)
                                {
                                    result[0] = i;
                                    result[1] = j;
                                }
                            }
                        }
                    }

                }
               
            }

            return result;

        }
    }
}

