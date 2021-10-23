using System;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(LongestPalindrome("ccc"));

        }

        public static string LongestPalindrome(string s)
        {
            string LongestPalindrome = string.Empty;

            if (s.Length == 0)
            {
                return LongestPalindrome;
            }

            if (s.Length == 1)
            {
                return s;
            }

            if (IsValidPalindrome(s))
            { 
                return s;
            }

            for (int i = 0; i < s.Length; i++)
            {
                //for each character we try create a word from it up to the point where we have a similar character 
                int j = i + 1;

                if (j < s.Length)
                {
                    int indexOfSameElement = s.IndexOf(s[i], j);

                    if (indexOfSameElement != -1)
                    {
                        int LengthOfSubString = (indexOfSameElement - i) + 1;

                        string subString = s.Substring(i, LengthOfSubString);

                        if (IsValidPalindrome(subString))
                        {
                            if (subString.Length > LongestPalindrome.Length)
                            {
                                LongestPalindrome = subString;
                            }
                        }
                    }
                    else
                    {
                        //means there is no other element , therefore we just consider this character 
                        if (LongestPalindrome.Length == 0)
                        {
                            LongestPalindrome = s[i].ToString();
                        }

                    }
                }


            }

            return LongestPalindrome;

        }


        public static bool IsValidPalindrome(string test)
        {
            bool IsValid = true;

            char[] reversedTestArray = test.ToCharArray();

            Array.Reverse(reversedTestArray);

            string reversed = string.Empty;

            foreach (var item in reversedTestArray)
            {
                reversed += item;
            }

            if (test == reversed)
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
