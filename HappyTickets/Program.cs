using System;
using System.Diagnostics;

namespace HappyTickets
{
    class Program
    {
        static void Main()
        {
            DummySolutions ds = new DummySolutions();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Перебор циклами нашел {ds.DummiestOne(11)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
            stopwatch.Reset();
        }
    }
}
