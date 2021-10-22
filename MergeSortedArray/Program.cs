using System;

namespace MergeSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] num1 = { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] num2 = { 2, 5, 6 };
            int n = 3;

            Merge(num1, m, num2, n);

        }


        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }
        }

        //public static void Merge(int[] nums1, int m, int[] nums2, int n)
        //{
        //    int lastIndexInNum1 = m;

        //    for (int i = 0; i < nums2.Length; i++)
        //    {
        //        nums1[lastIndexInNum1] = nums2[i];

        //        lastIndexInNum1++;
        //    }


        //    Array.Sort(nums1);
        //}
    }
}
