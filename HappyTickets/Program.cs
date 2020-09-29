using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    public static class Program
    {
        private static int MultipleForMethod(int countOfDigits)
        {
            int counter = 0;
            int subCounter = 0;
            switch (countOfDigits)
            {
                case 1:
                case 2:
                case 3:
                    return 9;
                case 4:
                case 5:
                    for (int i = 1; i <= 18; i++)
                    {
                        counter = 0;
                        for (int a = 0; a < 10; a++)
                        {
                            for (int b = 0; b < 10; b++)
                            {
                                for (int c = 0; c < 10; c++)
                                {
                                    for (int d = 0; d < 10; d++)
                                    {
                                        if ((a + b) == (c + d))
                                        {
                                            if (i == 18)
                                            {
                                                counter++;
                                            }
                                            if (c + d == i)
                                            {
                                                subCounter++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        subCounter = 0;
                    }
                    break;
                case 6:
                case 7:
                    for (int i = 1; i <= 27; i++)
                    {
                        counter = 0;
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
                                                if ((a + b + c) == (d + e + f))
                                                {
                                                    if (i == 27)
                                                    {
                                                        counter++;
                                                    }
                                                    if (d + e + f == i)
                                                    {
                                                        subCounter++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        subCounter = 0;
                    }
                    break;
                case 8:
                case 9:
                    for (int i = 1; i <= 36; i++)
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
                                                for (int g = 0; g < 10; g++)
                                                {
                                                    for (int h = 0; h < 10; h++)
                                                    {
                                                        if ((a + b + c + d) == (e + f + g + h))
                                                        {
                                                            if (i == 36)
                                                            {
                                                                counter++;
                                                            }
                                                            if (e + f + g + h == i)
                                                            {
                                                                subCounter++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        subCounter = 0;
                    }
                    break;
                case 10:
                case 11:
                    for (int i = 1; i <= 45; i++)
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
                                                for (int g = 0; g < 10; g++)
                                                {
                                                    for (int h = 0; h < 10; h++)
                                                    {
                                                        for (int j = 0; j < 10; j++)
                                                        {
                                                            for (int k = 0; k < 10; k++)
                                                            {
                                                                if ((a + b + c + d + e) == (f + g + h + j + k))
                                                                {
                                                                    if (i == 45)
                                                                    {
                                                                        counter++;
                                                                    }
                                                                    if (f + g + h + j + k == i)
                                                                    {
                                                                        subCounter++;
                                                                    }
                                                                }
                                                            }
                                                        }                                                        
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        subCounter = 0;
                    }
                    break;
            }
            return counter;
        }
        private static int StringMethod(int numberOfDigits)
        {
            int counter = 0;
            StringBuilder ticketNumber = new StringBuilder();
            ticketNumber.Append("1");
            for (int i = 0; i < numberOfDigits; i++)
            {
                ticketNumber.Insert(0, "0");
            }
            string str = ticketNumber.ToString();
            return counter;
        }

        //Small brain code above Main.

        static void Main(string[] args)
        {
            SmartSolutions ss = new SmartSolutions();            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"По моей собственной формуле v2 найдено {ss.countOfTicketsForDigit(5, true)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
            stopwatch.Restart();
            Console.WriteLine($"По моей собственной формуле найдено {countOfTicketsForDigit(10, true)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
            stopwatch.Restart();
            Console.WriteLine($"По методу перебора циклами найдено {MultipleForMethod(8)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
        }

        //IT'S BIG BRAIN TIME!

        public static double alternateFigureNumber(double i, double k)
        {
            double result;
            if (k < 2)
            {
                result = 1;
            } else
            {
                if (i < 0)
                {
                    result = 0;
                }
                else if (i == 0)
                {
                    result = 1;
                } else
                {
                    double previousRoot = alternateFigureNumber(i - 1, k);
                    double rootDiff = 0;
                    if (k == 2)
                    {
                        if (i >= 10 && i <=19)
                        {
                            rootDiff = -1;
                        }
                        else if (i <= 9)
                        {
                            rootDiff = 1;
                        }
                        else rootDiff = 0;
                    } else
                    {
                        double previousFigureNumber = alternateFigureNumber(i, k - 1);
                        double coefficient = alternateFigureNumber(i - 10, k - 1);
                        rootDiff = previousFigureNumber - coefficient;
                    }
                    result = previousRoot + rootDiff;
                }
            }
            return result;
        }
        static double figureNumber(double i, double k) //tested and this is bullshit.
        {
            if (i < 0)
            {
                return 0;
            }
            if (k == 1)
            {
                {
                    return 1;
                }
            }
            double n = i + 1;
            double result = (n + (k - 2)) / (k - 1) * figureNumber(i, k - 1);
            return result;
        }

        static double countOfTicketsForDigit(double k, bool withZero)
        {
            double result = 0;
            int theHalf = (int) k * 9 / 2;
            for (int i = 0; i < k * 9; i++)
            {
                if (i <= theHalf)
                {
                    result += Math.Pow(alternateFigureNumber(i, k), 2);
                } else //Remove and just double upper value + depends on odd or even -double or not double last value.
                {
                    int mirrorIndex = i - theHalf;
                    result += Math.Pow(alternateFigureNumber(mirrorIndex, k), 2);
                }
            }
            return withZero? result + 1 : result;
        }
    }
}
