using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishCalculator
{
    class Program
    {
        //Implement an RPN calculator that takes an expression like 19 2.14 + 4.5 2 4.3 / -
        // * which is usually expressed as (19 + 2.14) * (4.5 - 2 / 4.3) and responds with
        // 85.2974. The program should read expressions from standard input and print the
        // top of the stack to standard output when a newline is encountered. The program
        // should retain the state of the operand stack between expressions.

        

        static void Main(string[] args)
        {
            var arithmeticOperations = new Dictionary<string, Func<double, double, double>>()
            {
                {"+", (x,y) => x + y},
                {"-", (x,y) => x - y},
                {"*", (x,y) => x * y},
                {"/", (x,y) => x / y}
            };

            while (true)
            {
                Console.WriteLine("Enter valid expression:");
                string inputLine = Console.ReadLine();
                var stack = new Stack<double>();
                try
                {
                    foreach (var item in inputLine.Split(' '))
                    {
                        double num;
                        bool isNumeric = double.TryParse(
                            item,
                            NumberStyles.Number,
                            CultureInfo.InvariantCulture,
                            out num);

                        if (isNumeric)
                        {
                            stack.Push(num);
                        }
                        else
                        {
                            double param2 = stack.Pop(), param1 = stack.Pop();
                            double value = arithmeticOperations[item](param1, param2);
                            stack.Push(value);
                        }
                    }

                    Console.WriteLine(stack.Pop().ToString("N4", CultureInfo.InvariantCulture));
                }
                catch
                {
                    Console.WriteLine("Invalid expression");
                }
            }
        }
    }
}
