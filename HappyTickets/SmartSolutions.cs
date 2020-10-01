using System;
using System.Collections.Generic;

namespace HappyTickets
{
    /// Почему это работает?
    /// 
    /// Допустим, что имеется полный набор классических транспортных билетов, но их длина равна n.
    /// 
    /// В таком случае для четного n будут действовать следущие правила:
    /// 
    /// 1) (очевидное) Сравниваемые части будут иметь длину k = n / 2.
    /// 2) Сумма цифр (i) любой из сравниваемых частей не будет превышать k*9.
    /// 3) Количество счастливых билетов (E) для каждого i всегда равно квадрату какого-либо натурального числа. Пример: 
    ///     для шестизначного билета: i = 1, Е(1) = 9, i = 2, E(2) = 36 и т.д.
    /// 4) Ряд корней каждого E(i) для определенного k (F(k,i)) будет вычисляться по формуле:
    ///     
    ///     F(k, i) = F(k, i - 1) + F(k - 1, i) - F(k - 1, i - 10) ,
    ///     
    ///     при этом:
    ///     - если i < 0, то F(k,i) = 0;
    ///     - если i = 0, то F(k,i) = 1;
    ///     - если i > 0 и k = {0,1}, то F(k,i) = 1.
    ///   
    /// 5) Таким образом формула вычисления количества счастливых билетов любой четной длины равна:
    /// 
    ///     для 0 <= i <= k*9
    ///     
    ///     happyTickets = ∑(F(k,i)^2)
    ///     
    /// Для нечетного n расчет происходит иначе:
    /// 
    /// 1) Сравниваемые части будут иметь длину k = n / 2 - 1, т.е. сравниваются только первые и последние части длиной k. Середина исключается.
    ///     Таким образом получаем билет четной длины.
    /// 2) После расчета количества счастливых билетов для полученного билета четной длины, результат нужно умножить на 10.
    ///     
    /// Таким образом можно рекурсивно, аналогично задаче о поиске факториала, вычислить такой корень (метод ниже).
    /// А если еще и заполнять своеобразную таблицу значений, то поиск ускоряется на несколько порядков.
    /// 
    /// P.S. Это все придумал сам, без гугла и прочего за пару бессонных вечеров.

    public class SmartSolutions
    {
        public List<List<long>> SpeedTable { get; } = new List<List<long>>();

        public SmartSolutions()
        {
            SpeedTable.Insert(0, new List<long>());
            for (int i = 0; i < 10; i++)
            {
                SpeedTable[0].Insert(i, 1);
            }
            SpeedTable.Insert(1, new List<long>());
            for (int i = 0; i < 10; i++)
            {
                SpeedTable[1].Insert(i, i + 1);
            }
            for (int i = 10, j = 9; i < 20; i++, j--)
            {
                SpeedTable[1].Insert(i, j);
            }
        }

        private void AddToTable(int k, int i, long value)
        {
            k--;
            if (SpeedTable.Count <= k)
            {
                for (int j = SpeedTable.Count; j <= k; j++)
                {
                    SpeedTable.Add(new List<long>());
                }
            }
            try
            {
                if (SpeedTable[k][i] > 0)
                {
                    return;
                }
            }
            catch
            {
                SpeedTable[k].Insert(i, value);
            }
        }               

        /// <summary>
        /// Функция F(k, i), вычисляющая корень из суммы счастливых билетов, равных i.
        /// </summary>
        /// <param name="k">Длина сравниваемой части.</param>
        /// <param name="i">Сумма цифр сравниваемой части.</param>
        /// <returns>Корень суммы счастливых билетов, равных i.</returns>
        private long CalculateRoot(int k, int i) //TODO: replace try-catch with something...good.
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
                    AddToTable(k, i, result);
                }
                else
                {
                    long previousRoot;
                    try
                    {
                        previousRoot = SpeedTable[k - 1][i - 1];
                    }
                    catch
                    {
                        previousRoot = CalculateRoot(k, i - 1);
                    }
                    long rootDiff;
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
                        long previousFigureNumber;
                        try
                        {
                            previousFigureNumber = SpeedTable[k - 2][i];
                        }
                        catch
                        {
                            previousFigureNumber = CalculateRoot(k - 1, i);
                        }
                        long coefficient;
                        try
                        {
                            coefficient = SpeedTable[k - 2][i - 10];
                        }
                        catch
                        {
                            coefficient = CalculateRoot(k - 1, i - 10);
                        }
                        rootDiff = previousFigureNumber - coefficient;
                    }
                    result = previousRoot + rootDiff;
                    AddToTable(k, i, result);
                }
            }
            return result;
        }
        /// <summary>
        /// Вычисляет сумму квадратов значений функции.
        /// </summary>
        /// <param name="k">Количество цифр в билете.</param>
        /// <param name="withZero">Исключить билет, состоящий из нулей. Ведь в реальной жизни такого билета нет.</param>
        /// <returns>Количество счастливых билетов для k*2 значного билета.</returns>
        public double SumRootPower(int n, bool withZero)
        {
            int k = n / 2;
            int remainder = n % 2;
            double result = 0;
            int limit = k * 9;
            for (int i = 0; i <= limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            if (remainder.Equals(1))
            {
                result *= 10;
            }
            return withZero ? result : result - 1;
        }
        /// <summary>
        /// Вычисляет сумму квадратов значений функции. Оптимизирована для большого количества цифр в билете.
        /// </summary>
        /// <param name="k">Количество цифр в билете.</param>
        /// <param name="withZero">Исключить билет, состоящий из нулей. Ведь в реальной жизни такого билета нет.</param>
        /// <returns>Количество счастливых билетов для k*2 значного билета.</returns>
        public double SumRootPowerOptimized(int n, bool withZero)
        {
            int k = n / 2;
            int remainder = n % 2;
            int kRemainder = k % 2;
            double result = 0;
            int limit = k * 9 / 2;            
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            result += result;
            for (int i = 0; i <= kRemainder; i++)
            {
                result += Math.Pow(CalculateRoot(k, limit), 2);
            }
            if (remainder.Equals(1))
            {
                result *= 10;
            }
            return withZero ? result : result - 1;
        }

        //Skip me
        double FigureNumber(double k, double i) //figure number - good. But needs to calculate first, second etc rows up to K. lame method. Costs too much time for now. Throw it to deeeeeeeep box.
        {
            if (k == 1)
            {
                return 1;
            }
            double n = i + 1;
            return (n + (k - 2)) / (k - 1) * FigureNumber(k - 1, i);
        }
        //Don't look at me, I'm not ready yet.
        public double SumRootPowerSpecial(int n, bool withZero) //USELESS FOR NOW.
        {
            double result = 0;
            for (int i = 0; i < n * 9; i++)
            {
                double value = FigureNumber(Convert.ToDouble(n), Convert.ToDouble(i));
                result += Math.Pow(value, 2);
                Console.WriteLine(value);
            }
            return withZero ? result + 1 : result;
        }
    }
}