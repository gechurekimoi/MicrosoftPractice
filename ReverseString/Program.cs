using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            char[] arr = { 'h', 'e', 'l', 'l', 'o' };

            //ReverseString(arr);
            ReverseStringIterative(arr);
        }


        public static void ReverseString(char[] s)
        {
            //recursive way 
            helper(s, 0, s.Length - 1);
        }


        public static void helper(char[] s, int left, int right)
        {
            if (left >= right)
                return;

            char temp = s[left];

            s[left++] = s[right];

            s[right--] = temp;

            helper(s, left, right);
        }



        public static void ReverseStringIterative(char[] s)
        {
            int left = 0;

            int right = s.Length - 1;

            while( left < right)
            {
                //take the left character 
                char temp = s[left];

                s[left] = s[right];
                
                left++;
                
                s[right] = temp;

                right--;
               
            }

           
        }
    }
}
