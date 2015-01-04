using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenturyAndLeapYear
{
    class Program
    {

        //Write a program that accepts a year as input and outputs the century the year 
        //belongs in (e.g. 18th century's year ranges are 1701 to 1800) and whether or not the year is a leap year.
        // Pseudocode for leap year can be found here[1] .
        //Sample run:
        //Enter Year: 1996
        //Century: 20
        //Leap Year: Yes
        //Enter Year: 1900
        //Century: 19
        //Leap Year: No

        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                int year;

                try 
	            {	        
		            year = int.Parse(input);
	            }
	            catch (Exception)
	            {
		            continue;
	            }

                Console.WriteLine("{0} - {1}", GetCentury(year), IsLeapYear(year));
            }

        }

        static int GetCentury(int year)
        {
            if (year.ToString().Length < 3)
                return 1;
            else
                return year / 100;
        }

        static bool IsLeapYear(int year)
        {
            //if (year is not divisible by 4) then (it is a common year)
            //else
            //if (year is not divisible by 100) then (it is a leap year)
            //else
            //if (year is not divisible by 400) then (it is a common year)
            //else (it is a leap year)

            if (year % 4 != 0)
                return false;
            else if (year % 100 != 0)
                return true;
            else if (year % 400 != 0)
                return false;
            else
                return true;
        }
    }
}
