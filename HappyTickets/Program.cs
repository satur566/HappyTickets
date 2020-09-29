using System;
using System.Diagnostics;

namespace HappyTickets
{
    static class Program
    {
        static void Main() //Messy code, but priority is find some interesting unordinary smart solutions and compare completition time there.
        {
            int digitsCount = 3;
            SmartSolutions ss1 = new SmartSolutions();
            SmartSolutions ss2 = new SmartSolutions();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();            
            Console.WriteLine($"По моей собственной формуле v2 найдено {ss1.SumRootPowerOptimized(digitsCount, true)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");
            stopwatch.Restart();
            Console.WriteLine($"По моей собственной формуле найдено {ss2.SumRootPower(digitsCount, true)} билетов.");
            stopwatch.Stop();
            Console.WriteLine($"На это ушло {stopwatch.ElapsedMilliseconds} миллисекунд.");            
        }
    }
}
