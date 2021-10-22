using System;
using System.Collections.Generic;

namespace MaximumLengthOfUniqueStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<string> arr = new List<string>();

            arr.Add("cha");
            arr.Add("r");
            arr.Add("act");
            arr.Add("ers");

            Console.WriteLine(GetMaximumSize(arr));
        }


        static bool CheckIfStringIsUnique(string s)
        {
            HashSet<char> a = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (a.Contains(s[i]))
                {
                    return false;
                }

                a.Add(s[i]);
            }
            return true;
        }


        static List<string> GetPossibleCombinations(List<string> arr, int Index)
        {
            if(Index == arr.Count)
            {
                return new List<string>() { "" };
            }

            var uniqueCombinations = GetPossibleCombinations(arr, Index + 1);

            List<string> newCombinations = new List<string>();

            newCombinations.AddRange(uniqueCombinations);

            for (int i = 0; i < uniqueCombinations.Count; i++)
            {
                string teststring = arr[Index] + uniqueCombinations[i];

                if (CheckIfStringIsUnique(teststring))
                {
                    newCombinations.Add(teststring);
                }
            }


            return newCombinations;

        }


        static int GetMaximumSize(List<string> arr)
        {
            List<string> allPossibleCombinations = GetPossibleCombinations(arr, 0);

            int MaxLength = 0;

            foreach (var item in allPossibleCombinations)
            {
                if(item.Length > MaxLength)
                {
                    MaxLength = item.Length;
                }
            }

            return MaxLength;
        }


    }
}
