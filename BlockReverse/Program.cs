using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Input: list of elements and a block size k or some other variable of your choice
             *  Output: return the list of elements with every block of k elements reversed,
             *    starting from the beginning of the list.
             *  For instance, given the list 12, 24, 32, 44, 55, 66 and the block size 2,
             *    the result is 24, 12, 44, 32, 66, 55.
             */

            int[] nums;
            int blockSize;

            #region input
            try
            {
                string input;

                Console.WriteLine("List number items:");
                input = Console.ReadLine();

                var itemsAsString = input.Split( new[] {' '} ).ToList();
                nums = itemsAsString.Select(item => int.Parse(item)).ToArray();

                Console.WriteLine("Block size:");
                blockSize = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                Console.ReadKey();
                return;
            }
            #endregion

            int flipFrom = 0, flipTo = 0, goneSoFar = 0;

            for (int i = 0; i < nums.Count(); i++)
            {
                goneSoFar++;
                if (goneSoFar < blockSize)
                    continue;

                // šobrīd goneSoFar == blockSize
                flipTo = i;

                FlipBlock(nums, flipFrom, flipTo);

                flipFrom = i + 1;
                goneSoFar = 0;
            }

            nums.ToList().ForEach(num => Console.Write(num.ToString() + " "));
            Console.ReadLine();
        }

        static int[] FlipBlock(int[] nums, int flipFrom, int flipTo)
        {
            for (; flipFrom < flipTo; flipFrom++, flipTo--)
            {
                var temp = nums[flipFrom];
                nums[flipFrom] = nums[flipTo];
                nums[flipTo] = temp;
            }

            return nums;
        }
    }
}
