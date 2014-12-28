using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// [02/24/14] Challenge #149 [Easy] Disemvoweler

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
                string input = Console.ReadLine();
                input = input.ToLower();

                string result = "", removedVowels = "";

                foreach (char c in input)
                {
                    if (c == ' ')
                        continue;
                    else if (vowels.Contains(c))
                        removedVowels += c;
                    else
                        result += c;
                }

                Console.WriteLine("{0}" + Environment.NewLine + "{1}", result, removedVowels);
                Console.ReadLine();
            }
        }
    }
}
