namespace HappyTickets
{
    using System;
    using System.Diagnostics;

    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Задайте длину билета: ");
            int ticketDigitsCount = Convert.ToInt32(Console.ReadLine());
            Stopwatch stopwatch = new();
            stopwatch.Start();

            /*
             * Неоптимизированный самодельный метод
             */
            double unoptimalSmartSolutionResult =
                SmartSolutions
                    .CreateSolution()
                    .WithZeroTicket()
                    .WithTicketDigitCount(ticketDigitsCount)
                    .CalculateUnoptimally()
                    .GetResult();

            Console.WriteLine($"Поиск счастливых билетов длиной {ticketDigitsCount} самодельным методом c оптимизацией. Найдено: {unoptimalSmartSolutionResult}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
            stopwatch.Restart();

            /*
             * Оптимизированный самодельный метод
             */
            double optimalSmartSolutionResult =
                SmartSolutions
                    .CreateSolution()
                    .WithZeroTicket()
                    .WithTicketDigitCount(ticketDigitsCount)
                    .CalculateOptimally()
                    .GetResult();

            Console.WriteLine($"Поиск счастливых билетов длиной {ticketDigitsCount} самодельным методом без оптимизации. Найдено: {optimalSmartSolutionResult}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");

            /*
             * Метод двух массивов
             */
            stopwatch.Restart();
            double twoArraysMethodResult =
                DummySolutions
                    .CreateSolution()
                    .WithZeroTicket()
                    .WithTicketDigitCount(ticketDigitsCount)
                    .TwoArraysMethod()
                    .GetResult();

            Console.WriteLine($"Поиск счастливых билетов длиной {ticketDigitsCount} методом двух массивов. Найдено: {twoArraysMethodResult}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");

            /*
             * Простенький, но очень долгий метод подсчета через конвертацию строки.
             */
            if (ticketDigitsCount > 8)
            {
                Console.WriteLine($"Поиск счастливых билетов длиной {ticketDigitsCount} довольно глупым строковым методом будет идти долго. Запасись терпением.");
            }

            stopwatch.Restart();
            double stringMethodResult =
                DummySolutions
                    .CreateSolution()
                    .WithZeroTicket()
                    .WithTicketDigitCount(ticketDigitsCount)
                    .StringMethod()
                    .GetResult();

            Console.WriteLine($"Поиск счастливых билетов длиной {ticketDigitsCount} довольно глупым строковым методом. Найдено: {stringMethodResult}");
            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс.");
        }
    }
}
