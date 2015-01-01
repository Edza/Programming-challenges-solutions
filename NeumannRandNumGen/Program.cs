using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeumannRandNumGen
{
    class Program
    {
        //The middle-square method takes a number with an even number of digits, squares
        //it, and extracts the middle digits for the next iteration; for instance, if the
        //seed is 675248, the square is 455959861504, and the middle digits are 959861

        static void Main(string[] args)
        {
            int seed = 45505986; // seed
            while(true) {
                int randomNumber = NeumannRandom0To100(ref seed);
                Console.WriteLine(randomNumber.ToString());
                Console.ReadLine();
                if (randomNumber == -1)
                    break;
            }
        }

        static SortedSet<int> alreadySeen = new SortedSet<int>();

        static int NeumannRandom0To100(ref int seed)
        {
            if (seed == 0 || seed == -1)
                return -1;

            // jabūt pāra skaitlim ciparu
            if (seed.ToString().Length % 2 != 0)
                seed /= 10;

            unchecked
            {
                seed *= seed;
            }

            string newSeed = seed.ToString();
            int length = newSeed.Length;
            int middleFirst = length / 2; // int truncate division
            int generatedNumber = int.Parse(newSeed[middleFirst].ToString() + newSeed[middleFirst + 1].ToString());

            if (alreadySeen.Contains(generatedNumber))
                return -1;

            alreadySeen.Add(generatedNumber);
            return generatedNumber;
        }
    }
}
