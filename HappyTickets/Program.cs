using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    class Program
    {
        private static int MultipleForMethod()
        {
            int counter = 0;
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        for (int d = 0; d < 10; d++)
                        {
                            for (int e = 0; e < 10; e++)
                            {
                                for (int f = 0; f < 10; f++)
                                {
                                    if((a + b + c) == (d + e +f))
                                    {
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Перебор циклами нашел {MultipleForMethod()} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
        }
    }
}
