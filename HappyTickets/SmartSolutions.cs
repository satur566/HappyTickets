using System;
using System.Collections.Generic;

namespace HappyTickets
{
    public class SmartSolutions
    {
        public List<List<long>> SpeedTable { get; } = new List<List<long>>();

        public SmartSolutions() 
        {
            SpeedTable.Insert(0, new List<long>());
            for (int i = 0; i < 10; i++)
            {
                SpeedTable[0].Insert(i, 1);
            }
            SpeedTable.Insert(1, new List<long>());
            for (int i = 0; i < 10; i++)
            {
                SpeedTable[1].Insert(i, i + 1);
            }
            for (int i = 10, j = 9; i < 20; i++, j--)
            {
                SpeedTable[1].Insert(i, j);
            }
        }                     

        private void AddToTable (int k, int i, long value)
        {
            k--;
            if(SpeedTable.Count <= k)
            {
                for (int j = SpeedTable.Count; j <= k; j++)
                {
                    SpeedTable.Add(new List<long>());
                }                
            }
            try
            {
                if (SpeedTable[k][i] > 0)
                {
                    return;
                }
            }
            catch 
            {
                SpeedTable[k].Insert(i, value);
            }                                        
        }

        double FigureNumber(double k, double i) //figure number - good. But needs to calculate first, second etc rows up to K. lame method. Costs too much time for now. Throw it to deeeeeeeep box.
        {
            if (k == 1)
            {
                return 1;
            }
            double n = i + 1;
            return (n + (k - 2)) / (k - 1) * FigureNumber(k - 1, i);
        }

        private long CalculateRoot(int k, int i)
        {
            long result;
            if (k < 2)
            {
                result = 1;
            }
            else
            {
                if (i < 0)
                {
                    result = 0;
                }
                else if (i == 0)
                {
                    result = 1;
                    AddToTable(k, i, result);
                }
                else
                {
                    long previousRoot;
                    try
                    {
                        previousRoot = SpeedTable[k - 1][i - 1];
                    }
                    catch
                    {
                        previousRoot = CalculateRoot(k, i - 1);
                    }
                    long rootDiff;
                    if (k == 2)
                    {
                        if (i >= 10 && i <= 19)
                        {
                            rootDiff = -1;
                        }
                        else if (i <= 9)
                        {
                            rootDiff = 1;
                        }
                        else rootDiff = 0;
                    }
                    else
                    {
                        long previousFigureNumber;
                        try
                        {
                            previousFigureNumber = SpeedTable[k - 2][i];
                        }
                        catch
                        {
                            previousFigureNumber = CalculateRoot(k - 1, i);
                        }
                        long coefficient;
                        try
                        {
                            coefficient = SpeedTable[k - 2][i - 10];
                        }
                        catch
                        {
                            coefficient = CalculateRoot(k - 1, i - 10);
                        }
                        rootDiff = previousFigureNumber - coefficient;
                    }
                    result = previousRoot + rootDiff;
                    AddToTable(k, i, result);
                }
            }
            return result;
        }

        public double SumRootPower(int k, bool withZero)
        {
            double result = 0;
            int limit = k * 9;
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            return withZero ? result + 1 : result;
        }

        public double SumRootPowerOptimized(int k, bool withZero)
        {
            double result = 0;
            int limit = k * 9 / 2;
            int remainder = k * 9 % 2;
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            result += result;
            for (int i = 0; i <= remainder; i++)
            {
                result += Math.Pow(CalculateRoot(k, limit), 2);
            }
            return withZero ? result : result - 1;
        }

        public double SumRootPowerSpecial(int k, bool withZero) //Work in progress.
        {
            double result = 0;
            for (int i = 0; i < k * 9; i++)
            {
                double value = FigureNumber(Convert.ToDouble(k), Convert.ToDouble(i));
                result += Math.Pow(value, 2);
                Console.WriteLine(value);
            }
            return withZero ? result + 1 : result;
        }
    }
}