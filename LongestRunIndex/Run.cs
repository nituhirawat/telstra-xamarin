using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LongestRunIndex
{
    class Run
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the string value:");
            string s = Console.ReadLine().ToString();
            Console.WriteLine(IndexOfLongestRun(s));
            Console.ReadLine();
        }

        //Returns the zero-based index of the longest run in a string.
        public static int IndexOfLongestRun(string str)
        {
            //Matching the string with a regular expression to get a collection of strings of a particular pattern
            MatchCollection mc = Regex.Matches(str, "(?i)(?:([a-z])\\1{1,})");
            int maxLength = 0;
            int index = -1;
            foreach (Match m in mc)
            {
                //Finds the longest string within the collection and getting the index of its first character
                if (m.Length > maxLength)
                {
                    maxLength = m.Length;
                    index = m.Index;
                }

            }
            return index;
        }

    
    }
}
