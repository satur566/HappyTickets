using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    class Program
    {
        private static void MultipleForMethod()
        {
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
                                        Console.WriteLine($"{a}{b}{c}{d}{e}{f}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {            
            MultipleForMethod();
        }
    }
}
