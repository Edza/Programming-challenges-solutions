using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblem3
{
    class Program
    {
        // largest prime factor 600851475143 
        const string ADDR = "http://primes.utm.edu/lists/small/10000.txt";

        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string primesStr = wc.DownloadString(ADDR);
            // notīram beigas
            primesStr = primesStr.Replace("end.", "");
            // pirmā daļa ir teksts
            primesStr = primesStr.Split(new[] { "\r\n\r\n" }, 0)[1];
            primesStr = primesStr.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
            int[] primes = primesStr.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(item => int.Parse(item.Trim())).ToArray();

            long num = 600851475143;

            for (long i = primes.Length - 1; i >= 0; i--)
            {
                if(num % primes[i] == 0)
                {
                    Console.WriteLine(primes[i].ToString());
                    Console.ReadLine();
                }
            }
        }
    }
}
