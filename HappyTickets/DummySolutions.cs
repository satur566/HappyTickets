namespace HappyTickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    //Тут собраны предельно глупые решения задачи.
    internal class DummySolutions: AbstractSolution<DummySolutions>
    {
        internal DummySolutions TwoArraysMethod()
        {
            long counter = 0;
            StringBuilder ticketNumber = new();
            for (int i = 0; i < this.DigitsCount / 2; i++)
            {
                _ = ticketNumber.Append("9");
            }

            double highestNumber = Convert.ToDouble(ticketNumber.ToString());
            bool isOdd = this.DigitsCount % 2 == 0;
            for (int leftPart = 0; leftPart <= highestNumber; leftPart++)
            {
                for (int rightPart = 0; rightPart <= highestNumber; rightPart++)
                {
                    long leftPartSum = GetDigits(leftPart).Sum();
                    long rightPartSum = GetDigits(rightPart).Sum();
                    if (leftPartSum == rightPartSum)
                    {
                        counter++;
                    }
                }
            }

            counter = isOdd ? counter : counter * 10;
            this.Result = this.CalculateWithZeroTicket ? counter : counter - 1;
            return this;
        }

        private static IEnumerable<int> GetDigits(int source)
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
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
