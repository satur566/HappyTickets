using System;
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
        static void Main(string[] args)
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
