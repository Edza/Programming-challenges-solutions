using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem1
{
    /*
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
     * The sum of these multiples is 23.
     * Find the sum of all the multiples of 3 or 5 below 1000.
     */

    class Program
    {
        static void Main(string[] args)
        {
            var arr = Enumerable.Range(1, 999).ToList();
            int sum = arr.Where(number => number % 3 == 0 || number % 5 == 0)
                         .Aggregate((sumSoFar, next) => next + sumSoFar);
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
