using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GuessLettersGame
{
    class Program
    {
        const string DICT_ADDR = "http://www.desiquintans.com/downloads/nounlist.txt";

        static void Main(string[] args)
        {
            var wc = new WebClient();
            var text =  wc.DownloadString(DICT_ADDR);

            var words = text.Split(new[] { '\n' })
                .Select(word => word.Trim())
                .Where(word => word.Count() == 5 && word.All(symbol => Char.IsLetter(symbol)))
                .ToList();

            var r = new Random();
            int triesLeft = 0;
            string secret = "";

            while (true)
            {
                if (triesLeft == 0)
                {
                    if(secret != "") // pirmā reize
                        Console.WriteLine(secret);

                    triesLeft = 5;

                    Console.WriteLine("Jauns vārds!");
                    secret = words[r.Next(0, words.Count)];
                }

                var input = Console.ReadLine();

                if (input.Length != 5)
                    continue;

                bool allMatch = true;

                for (int i = 0; i < 5; i++)
                {
                    if (input[i] != secret[i])
                    {
                        if (secret.Contains(input[i]))
                            Console.Write(".");
                        else
                            Console.Write("x");
                        allMatch = false;
                    }
                    else
                    {
                        Console.Write("!");
                    }  
                }

                Console.Write("\r\n");

                if (allMatch)
                {
                    triesLeft = 0;
                    Console.WriteLine("Uzvara!");
                    continue;
                }

                triesLeft--;
            }
        }
    }
}
