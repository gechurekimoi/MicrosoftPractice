using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDeletions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Console.WriteLine(MinDeletions("aaabbbcc"));
            //Console.WriteLine(MinDeletions("aab"));
            //Console.WriteLine(MinDeletions("ceabaacb"));
            //Console.WriteLine(MinDeletions("eeee"));
            //Console.WriteLine(MinDeletions("example"));

            //ans = 276
            Console.WriteLine(MinDeletions("abcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwzabcdefghijklmnopqrstuvwxwz"));
        }

        public static int MinDeletionsOld(string s)
        {
            if (s == null || s == string.Empty)
                return 0;

            int res = 0,
                curFreq = Int32.MaxValue;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                    dict.Add(c, 0);

                dict[c] += 1;
            }


            var dicValuesOrdered = dict.OrderByDescending(x => x.Value).Select(x => x.Value).ToList();

            foreach (var item in dicValuesOrdered)
                if (curFreq <= item)
                {
                    res += curFreq == 0 ? item : item - curFreq + 1;
                    curFreq = curFreq == 0 ? 0 : curFreq - 1;
                }
                else
                    curFreq = item;

            return res;
        }

        public static int MinDeletions(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }


            if (s.Length == 1)
            {
                return 0;
            }


            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

          

            int NumberOfDeletedElements = 0;

            HashSet<int> uniqueValues = new HashSet<int>();

            if(dict.Count == 1)
            {
                //this means we only have one character which is unique 
                return 0;
            }
            else
            {

                foreach (var item in dict)
                {
                    if (uniqueValues.Contains(item.Value))
                    {
                        int val = item.Value;

                        for (int i = 0; i < item.Value; i++)
                        {
                            NumberOfDeletedElements++;

                            val = val - 1;

                            if (!uniqueValues.Contains(val))
                            {
                                uniqueValues.Add(val);
                                break;
                            }

                        }
                    }
                    else
                    {
                        uniqueValues.Add(item.Value);
                    }
                }


                return NumberOfDeletedElements;


            }


        }

    }
}
