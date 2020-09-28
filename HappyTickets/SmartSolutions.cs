using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    class SmartSolutions
    {
        public SmartSolutions() { } //TODO: заполнить при инициализации класса. 0 и 1 сублисты значениями 000000000 и 111111111-1-1-1-1-1-1-1-1-1
        
        private List<List<long>> speedTable = new List<List<long>>();

        public List<List<long>> SpeedTable
        {
            get
            {
                if (speedTable.Count.Equals(0))
                {
                    speedTable.Insert(0, new List<long>());
                    for (int i = 0; i < 10; i++)
                    {
                        speedTable[0].Insert(i, 1);
                    }
                }
                return speedTable;
            }
        }

        private void AddToTable (int i, int k, long value)
        {
            k--;
            if(speedTable.Count < k)
            {
                for (int j = speedTable.Count; j < k; j++)
                {
                    speedTable.Add(new List<long>());
                }
                speedTable.Insert(k, new List<long>());
            }
            try
            {
                if (speedTable[k][i] > 0)
                {
                    return;
                }
            }
            catch 
            {
                speedTable[k].Insert(i, value);
            }                                        
        }

        private long alternateFigureNumber(int i, int k)
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
                    AddToTable(i, k, result);
                }
                else
                {
                    long previousRoot = 0;
                    try
                    {
                        previousRoot = speedTable[k - 1][i - 1];
                    }
                    catch
                    {
                        previousRoot = alternateFigureNumber(i - 1, k);
                    }
                    long rootDiff = 0;
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
                        long previousFigureNumber = 0;
                        try
                        {
                            previousFigureNumber = speedTable[k - 2][i];
                        }
                        catch
                        {
                            previousFigureNumber = alternateFigureNumber(i, k - 1);
                        }
                        long coefficient = 0;
                        try
                        {
                            coefficient = speedTable[k - 2][i - 10];
                        }
                        catch
                        {
                            coefficient = alternateFigureNumber(i - 10, k - 1);
                        }
                        rootDiff = previousFigureNumber - coefficient;
                    }
                    result = previousRoot + rootDiff;
                    AddToTable(i, k, result);
                }
            }
            return result;
        }

        public double countOfTicketsForDigit(int k, bool withZero)
        {
            double result = 0;
            int theHalf = (int)k * 9 / 2;
            for (int i = 0; i < k * 9; i++)
            {
                if (i <= theHalf)
                {
                    result += Math.Pow(alternateFigureNumber(i, k), 2);
                }
                else
                {
                    int mirrorIndex = i - theHalf;
                    result += Math.Pow(alternateFigureNumber(mirrorIndex, k), 2);
                }
                Console.WriteLine($"{i} из {k * 9}");
            }
            return withZero ? result + 1 : result;
        }
    }
}
