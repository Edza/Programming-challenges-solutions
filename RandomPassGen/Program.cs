using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPassGen
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int numChars;

                Console.WriteLine("Cik ciparu parolei? (-1 lai izietu)");

                try
                {
                    numChars = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Nepareizi ievaddati!");
                    continue;
                }

                if (numChars == -1)
                    break;

                var validChars = "1234567890!@#$%^&*()";
                validChars += "QWERTYUIOPASDFGHJKLZXCVBNM";
                validChars += "QWERTYUIOPASDFGHJKLZXCVBNM".ToLower();

                var validCharsSeperated = validChars.ToCharArray();

                string output = "";

                Random r = new Random();
                int max = validCharsSeperated.Count() - 1;

                for (int i = 0; i < numChars; i++)
                {
                    output += validCharsSeperated[r.Next(0, max)];
                }

                Console.WriteLine(output);
            }
        }
    }
}
