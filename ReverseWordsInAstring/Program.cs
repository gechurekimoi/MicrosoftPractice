using System;
using System.Text;

namespace ReverseWordsInAstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Console.WriteLine(ReverseWords("  Bob    Loves  Alice   "));
        }


        public static string ReverseWords(string s)
        {

            string[] words = s.Split(' ');

            //string newString = "";

            StringBuilder newString = new StringBuilder();

            int Index = words.Length-1;
            
            while(Index > -1)
            {
                if (!string.IsNullOrEmpty(words[Index]))
                {
                    newString.Append(words[Index]).Append(" ");
                }

                Index--;
            }

            

            return newString.ToString().Trim();

        }
    }
}
