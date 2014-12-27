using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Input: a number
                //Output : the next higher number that uses the same set of digits.

                int x, num;

                Console.WriteLine("Number:");

                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    return;
                }

                if (num < 0)
                    return;

                var digits = new List<int>();
                x = num;

                while (x > 0)
                {
                    digits.Add(x % 10);
                    x = x / 10;
                }

                if (num == 0)
                    digits = new List<int>() { 0 };

                for (int i = num + 1; ; i++)
                {
                    string whatsLeftOfCurrentNum = i.ToString();
                    if (digits.All((digit) =>
                    {
                        bool result;

                        result = whatsLeftOfCurrentNum.Contains(digit.ToString()[0]);
                        if (result)
                            whatsLeftOfCurrentNum = whatsLeftOfCurrentNum.ReplaceFirst(digit.ToString(), " ");

                        return result;
                    }))
                    {
                        Console.WriteLine(i.ToString());
                        break;
                    }
                }
            }
        }
    }

    public static class Extensions
    {
        public static string ReplaceFirst(this string original, string oldValue, string newValue)
        {
            if (String.IsNullOrEmpty(original))
                return String.Empty;
            if (String.IsNullOrEmpty(oldValue))
                return original;
            if (String.IsNullOrEmpty(newValue))
                newValue = String.Empty;
            int loc = original.IndexOf(oldValue);
            return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
        }
    }
}
