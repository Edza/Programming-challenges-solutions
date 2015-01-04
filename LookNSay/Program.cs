using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookNSay
{
	class Program
	{
		//The Look and Say sequence is an interesting sequence of numbers where each term
		// is given by describing the makeup of the previous term.
		//The 1st term is given as 1. The 2nd term is 11 ('one one') because the first term
		// (1) consisted of a single 1. The 3rd term is then 21 ('two one') because the
		// second term consisted of two 1s. The first 6 terms are:
		//1
		//11
		//21
		//1211
		//111221
		//312211

		static void Main(string[] args)
		{
			decimal num;

			try 
			{	        
				num = decimal.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid input");
				Console.ReadLine();
				return;
			}

			while (true)
			{
				num = LookNSay(num);
				Console.WriteLine(num.ToString());
				Console.ReadLine();
                if (num == -1)
                    break;
			}
			
		}

		static decimal LookNSay(decimal num)
		{
			string result = "";

			int digitToCount = -1, count = 0;

			foreach(var digit in num.ToString()) {
				if (int.Parse(digit.ToString()) != digitToCount)
				{
                    if (digitToCount != -1)
                    {
                        result += count.ToString() + digitToCount.ToString();
                        count = 0;
                    }
					digitToCount = int.Parse(digit.ToString());
					count++;                  
				}
				else
				{
					count++;
				}
			}

            result += count.ToString() + digitToCount.ToString();
            try
            {
                return decimal.Parse(result);
            }
            catch
            {
                return -1;
            }
		}
	}
}
