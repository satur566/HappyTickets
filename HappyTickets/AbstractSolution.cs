namespace HappyTickets
{
    internal abstract class AbstractSolution<T> where T : AbstractSolution<T>
    {
        protected double Result { private get; set; }
        protected int DigitsCount { get; private set; }
        protected bool CalculateWithZeroTicket { get; private set; }

        internal T WithZeroTicket()
        {
            this.CalculateWithZeroTicket = true;
            return (T)this;
        }

        internal T WithTicketDigitCount(int digitsCount)
        {
            this.DigitsCount = digitsCount;
            return (T)this;
        }

        internal double GetResult() => this.Result;
    }
}
