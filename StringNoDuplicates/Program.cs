using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringNoDuplicates
{
    //you have a string "ddaaiillyypprrooggrraammeerr". We want to remove all the consecutive duplicates and put them in a separate string, which yields two separate instances of the string "dailyprogramer".
    //use this list for testing:
    //input: "balloons"
    //expected output: "balons" "lo"
    //input: "ddaaiillyypprrooggrraammeerr"
    //expected output: "dailyprogramer" "dailyprogramer"
    //input: "aabbccddeded"
    //expected output: "abcdeded" "abcd"
    //input: "flabby aapples"
    //expected output: "flaby aples" "bap"

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                dynamic d = RemoveDuplicates(input);
                if (d == null)
                {
                    Console.WriteLine("Tu esi muļķis");
                    continue;
                }
                Console.WriteLine("{0}\r\n{1}", d.Cleaned, d.LeftOvers);
            }
        }

        static object RemoveDuplicates(string input)
        {
            string cleaned = "", leftOvers = "";
            char last = '\0'; // neiespējams

            if(input == null || input.Length == 0)
                return null;

            var enumerator = input.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current != last)
                {
                    cleaned += enumerator.Current;
                    last = enumerator.Current;
                }
                else
                {
                    leftOvers += enumerator.Current;
                }

            } 

            return new { Cleaned = cleaned, LeftOvers = leftOvers };
        }
    }
}
