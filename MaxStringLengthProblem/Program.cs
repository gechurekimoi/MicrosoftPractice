using System;
using System.Collections;
using System.Collections.Generic;

namespace MaxStringLengthProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ArrayList s = new ArrayList();
            s.Add("un");
            s.Add("iq");
            s.Add("ue");

            Console.Write(maxLength(s));
        }


        // Function to check if all the
        // string characters are unique
        static bool check(string s)
        {

            HashSet<char> a = new HashSet<char>();

            // Check for repetition in
            // characters
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

        // Function to generate all possible
        // strings from the given array
        static ArrayList helper(ArrayList arr,int ind)
        {

            // Base case
            if (ind == arr.Count)
                return new ArrayList() {""};

            // Consider every string as
            // a starting substring and
            // store the generated string
            ArrayList tmp = helper(arr, ind + 1);

            ArrayList ret = new ArrayList(tmp);

            // Add current string to result of
            // other strings and check if
            // characters are unique or not
            for (int i = 0; i < tmp.Count; i++)
            {
                string test = (string)tmp[i] + (string)arr[ind];

                if (check(test))
                    ret.Add(test);
            }
            return ret;
        }

        // Function to find the maximum
        // possible length of a string
        static int maxLength(ArrayList arr)
        {
            ArrayList tmp = helper(arr, 0);

            int len = 0;

            // Return max length possible
            for (int i = 0; i < tmp.Count; i++)
            {
                len = len > ((string)tmp[i]).Length ? len :((string)tmp[i]).Length;
            }

            // Return the answer
            return len;
        }
    }
}
