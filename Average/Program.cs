using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = MathUtils.Average(11, 6);
            Console.WriteLine("The average value is: {0}", result);
            Console.ReadLine();
        }
    }
    public class MathUtils
    {
        public static double Average(int a, int b)
        {
            return (double)(a + b) / 2; //here is the fix - brackets were missing and casting to double is required to get proper results
        }
    }
}
