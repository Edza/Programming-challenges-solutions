using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _30digitsOfPi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Izmantosim viduslaiku indieša Madhava formulu
            // Piezīme: tehniski runājot tikai pirmās zīmes sakrīt precīzi, jo šis algoritms nav perfekts
            // un decimal atbalsta 28-29 precīzas zīmes nevis 30 ;)

            Decimal approxPi = 0;
            for (int k = 0; k < 10000000; k++)
            {
                var value = Math.Pow((-1 / 3.0), k) / (2 * k + 1);
                approxPi += (Decimal)value;
            }

            approxPi *= (Decimal)Math.Sqrt(12);

            var _30hashes = new string('#', 30);

            Console.WriteLine(approxPi.ToString("#." + _30hashes));
            Console.ReadLine();
        }
    }
}
