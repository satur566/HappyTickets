namespace HappyTickets
{
    using System;
    using System.Text;

    //Тут собраны предельно глупые решения задачи.
    internal class DummySolutions: AbstractSolution<DummySolutions>
    {
        internal static DummySolutions CreateSolution() => new();
        //Максимально глупое, служащее скорее для проверки работы алгоритма для длины билета до 12 цифр.
        internal DummySolutions DummiestOne()
        {
            int counter = 0;
            switch (this.DigitsCount)
            {
                //Для билета длиной 1 каждый билет по сути счастливый, т.к. правая и левая часть цифр, его составляющих всегда равны :)
                case 1:
                case 2:
                    counter = 10;
                    break;
                case 3:
                    counter = 100;
                    break;
                case 4:
                    for (int a = 0; a < 10; a++)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            for (int c = 0; c < 10; c++)
                            {
                                for (int d = 0; d < 10; d++)
                                {
                                    if (a + b == c + d)
                                    {
                                        counter++;
                                    }
                                }
                            }
                        }
                    }

                    break;
                case 5:
                    for (int a = 0; a < 10; a++)
                    {
                        for (int b = 0; b < 10; b++)
                        {
                            for (int c = 0; c < 10; c++)
                            {
                                for (int d = 0; d < 10; d++)
                                {
                                    if (a + b == c + d)
                                    {
                                        counter++;
                                    }
                                }
                            }
                        }
                    }

                    counter *= 10;
                    break;
                case 6:
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
                                            if (a + b + c == d + e + f)
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
                                            if (a + b + c == d + e + f)
                                            {
                                                counter++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    counter *= 10;
                    break;
                case 8:
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
                                                    if (a + b + c + d == e + f + g + h)
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
                                                    if (a + b + c + d == e + f + g + h)
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

                    counter *= 10;
                    break;
                case 10:
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
                                                            if (a + b + c + d + e == f + g + h + j + k)
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
                                                            if (a + b + c + d + e == f + g + h + j + k)
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

                    counter *= 10;
                    break;
            }

            this.Result = this.CalculateWithZeroTicket ? counter : counter - 1;
            return this;
        }

        internal DummySolutions StringMethod()
        {
            long counter = 1;
            StringBuilder ticketNumber = new();
            for (int i = 0; i < this.DigitsCount; i++)
            {
                _ = ticketNumber.Append("9");
            }

            double highestNumber = Convert.ToDouble(ticketNumber.ToString());
            for (double i = 0; i < highestNumber; i++)
            {
                counter += this.SimpleCounter(i.ToString().PadLeft(this.DigitsCount, '0'));
            }

            this.Result = this.CalculateWithZeroTicket ? counter : counter - 1;
            return this;
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
