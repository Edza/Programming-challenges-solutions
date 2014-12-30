using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvatarGenerator
{
    public enum Pixel { Red = 0, Green = 1, Blue = 2, White = 3 };   

    public static class Extensions
    {
        public static ConsoleColor ToConsoleColor(this Pixel value)
        {
            switch (value)
            {
                case Pixel.Blue:
                    return ConsoleColor.Blue;
                case Pixel.Red:
                    return ConsoleColor.Red;
                case Pixel.Green:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.White;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Username:");
                string input = Console.ReadLine();
                int hash = input.GetHashCode();

                // 4x4
                var colorBlocks = new Pixel[16];

                var bits = new BitArray(new[] { hash });

                // katri 2 biti apzīmē krāsu
                for (int i = 0; i < bits.Length; i += 2)
                {
                    int[] colorInt = new[] { 0 };
                    var colorBits = new BitArray(new[] { colorInt[0] });
                    colorBits.Set(0, bits[i]);
                    colorBits.Set(1, bits[i + 1]);
                    colorBits.CopyTo(colorInt, 0);
                    colorBlocks[i / 2] = (Pixel)colorInt[0];
                }

                for (int i = 0; i < 16; i++)
                {
                    Console.BackgroundColor = colorBlocks[i].ToConsoleColor();
                    Console.Write("  ");
                    if ((i + 1) % 4 == 0)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }
        }
    }
}
