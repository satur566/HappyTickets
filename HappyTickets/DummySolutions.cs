using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    public class DummySolutions
    {
        public DummySolutions() { }
        public int DummiestOne(int countOfDigits)
        {
            int counter = 0;
            int subCounter = 0;
            switch (countOfDigits)
            {
                case 1:
                case 2:
                case 3:
                    return 10;
                case 4:
                case 5:
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
                                                counter++;
                                        }
                                    }
                                }
                            }
                        }
                    break;
                case 6:
                case 7:
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

                                                        counter++;

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }                    
                    break;
                case 8:
                case 9:
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
                                                                counter++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    break;
                case 10:
                case 11:
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
                                                                        counter++;
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
                    break;
            }
            return counter;
        }
        public long StringMethod(int numberOfDigits)
        {

            numberOfDigits = numberOfDigits > 2 ? numberOfDigits - numberOfDigits % 2 : numberOfDigits;
            long counter = 1;
            StringBuilder ticketNumber = new StringBuilder();
            for (int i = 0; i < numberOfDigits; i++)
            {
                ticketNumber.Append("9");
            }
            long highestNumber = Convert.ToInt64(ticketNumber.ToString());
            for (long i = 0; i < highestNumber; i++)
            {
                counter += SimpleCounter(i.ToString().PadLeft(numberOfDigits, '0'));
            }
            return counter;
        }

        private int SimpleCounter(string ticketNumber)
        {
            int divider = ticketNumber.Length / 2;
            string firstPart = ticketNumber.Substring(0, divider);
            string secondPart = ticketNumber.Substring(divider);
            int firstSum = 0;
            int secondSum = 0;
            for (int i = 0; i < firstPart.Length; i++)
            {
                firstSum += Convert.ToInt32(firstPart[i]);
                secondSum += Convert.ToInt32(secondPart[i]);                
            }
            return firstSum.Equals(secondSum) ? 1 : 0;
        }
    }
}
