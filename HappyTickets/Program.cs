namespace HappyTickets
{
    using System;
    using System.Diagnostics;

    static class Program
    {
        static void Main() //Messy code, but priority is find some interesting unordinary smart solutions and compare completition time there.
            //And yep, no exception handling untill I finish this task.
        {
            Console.Write("Задайте длину билета: ");
            int k = Convert.ToInt32(Console.ReadLine());
            SmartSolutions smartSolutions = new();
            SmartSolutions smartSolutionsDuplicate = new();
            DummySolutions dummySolutions = new();
            Stopwatch stopwatch = new();
            stopwatch.Start();
            Console.WriteLine($"Поиск счастливых билетов длиной {k} самодельным методом c оптимизацией. Найдено: {smartSolutions.SumRootPowerOptimized(k, true)}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
            stopwatch.Restart();
            Console.WriteLine($"Поиск счастливых билетов длиной {k} самодельным методом без оптимизации. Найдено: {smartSolutionsDuplicate.SumRootPower(k, true)}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
            if (k > 11)
            {
                Console.WriteLine($"Поиск счастливых билетов длиной {k} методом перебора циклами не может быть посчитан.");
            }
            else
            {
                stopwatch.Restart();
                Console.WriteLine($"Поиск счастливых билетов длиной {k} методом перебора циклами. Найдено: {dummySolutions.DummiestOne(k)}");
                stopwatch.Stop();
                Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
            }

            if (k > 8)
            {
                Console.WriteLine($"Поиск счастливых билетов длиной {k} довольно глупым строковым методом будет идти долго. Запасись терпением.");
            }

            stopwatch.Restart();
            Console.WriteLine($"Поиск счастливых билетов длиной {k} довольно глупым строковым методом. Найдено: {dummySolutions.StringMethod(k)}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
        }
    }
}
