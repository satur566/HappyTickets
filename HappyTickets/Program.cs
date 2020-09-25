﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    class Program
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
                                    //Console.WriteLine($"{a+b+c}\t{subCounter}");
                                    //subCounter = 0;
                                }
                            }
                        }
                        Console.WriteLine($"{subCounter}");
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
                        Console.WriteLine($"{i} {subCounter}");
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
                        Console.WriteLine($"{i} {subCounter}");
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
                        Console.WriteLine($"{i} {subCounter}");
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
        static void Main(string[] args)
        {
            StringMethod(2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Перебор циклами нашел {MultipleForMethod(11)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
            stopwatch.Reset();
        }


        //IT'S BIG BRAIN TIME!


        static long figureDigit(int i, int k)
        {
            if ((i < 0) || (k < 0))
            {
                return 0;
            }
            int n = i + 1;
            long result = (n + k - 2) / (k - 1) * figureDigit(i, k - 1);
            return result;
        }

        static long coutOfTicketsForDigit(int i, int k)
        {
            long result = figureDigit(i, k) + figureDigit(i, k - 1) + figureDigit(i - 10, k - 1);
            long doubleResult = (long) Math.Pow(result, 2);
            return doubleResult;
        }
    }
}