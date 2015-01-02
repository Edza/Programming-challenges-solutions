using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANDU
{
    class Program
    {
        // xn+1 = 65539 · xn (mod 231), with x0 odd.
        static uint seed = 9991;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Randu0to1().ToString("0.##"));
                Console.ReadLine();
            }
        }

        private static uint Randu()
        {
            unchecked
            {
                seed = ((uint)65539 * (uint)seed) % (uint)Math.Pow(2, 31);
            }
            return seed;
        }

        private static decimal Randu0to1()
        {
            return (decimal)Randu() / (decimal)Math.Pow(2, 31);
        }
    }
}
