using System;
using System.Collections.Generic;

namespace HappyTickets
{
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

        double FigureNumber(double k, double i) //figure number - good. But needs to calculate first, second etc rows up to K. lame method. Costs too much time for now. Throw it to deeeeeeeep box.
        {
            if (k == 1)
            {
                return 1;
            }
            double n = i + 1;
            return (n + (k - 2)) / (k - 1) * FigureNumber(k - 1, i);
        }

        /// Почему это работает?
        /// 
        /// Будем называть счастливым билетом совпадение суммы каждой цифры k-значного числа с суммой любого другого k-значного числа.
        /// В таком случае для каждого ряда чисел от 0 до N, длина которого в цифрах равна K*2 (т.е. для K=3, N будет ограничен 999999) 
        /// будет действовать следующие правила:
        /// 1) Количество разчилных сумм цифр правой или левой половины счастливого билета будет равно K*9.
        /// 2) Количеством таких билетов, приходящихся на каждую сумму - будет являтся число, из которого можно извлечь целый корень.
        /// 3) Первые 10 таких корней - фигурные числа порядка K, так при K=3 это будут треугольные числа 1,3,6,10, при K=4 - тетраэдральные и т.д.
        ///     Исчисляются по формуле(при k >=3): F(k,i) = (n + (k - 2))/(k - 1) * F(k - 1, i);
        /// 4) Все последующие корни - являются фигурными числами порядка K с вычитанием определенного коэфициента, равного F(k-1,i)-F(k-1, i - 10);
        /// 
        /// Таким образом можно вычислить количество счастливых билетов любой длины, при условии, что длина - четное число.
        /// 
        /// Но существует иной способ:
        /// 
        /// Каждый корень можно вычислить по формуле F(k, i) = F(k, i -1) + F(k - 1, i) - F(k - 1, i - 10)
        /// при следующих условиях:
        /// 1) Для любого i:
        ///     если k = 0, 1, то F = 1;        
        /// 2) Для любого k:
        ///     a) если i = 0, F = 1; 
        ///     б) если i < 0, F = 0;
        /// 
        /// Таким образом можно рекурсивно, аналогично задаче о поиске факториала, вычислить такой корень (метод ниже).
        /// А если еще и заполнять своеобразную таблицу значений, то поиск ускоряется на несколько порядков.
        /// 
        /// P.S. Это все придумал сам, без гугла и прочего за пару бессонных вечеров, а потом много времени убил на первую часть, так и не доделав. Зато сделал вторую =)

        /// <summary>
        /// Функция F(k, i), вычисляющая i-e число ряда фигурных чисел порядка k, измененное на определенный коэфициент.
        /// </summary>
        /// <param name="k">Порядок фигурного числа.</param>
        /// <param name="i">Номер фигурного часла в ряду.</param>
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
        /// <param name="k">Количество цифр в каждом из сравниваемых чисел ряда.</param>
        /// <param name="withZero">Исключить билет, состоящий из нулей. Ведь в реальной жизни такого билета нет.</param>
        /// <returns>Количество счастливых билетов для k*2 значного билета.</returns>
        public double SumRootPower(int k, bool withZero)
        {
            double result = 0;
            int limit = k * 9;
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            return withZero ? result + 1 : result;
        }
        /// <summary>
        /// Вычисляет сумму квадратов значений функции. Оптимизирована для большого количества цифр в числе ряда.
        /// </summary>
        /// <param name="k">Количество цифр в каждом из сравниваемых чисел ряда.</param>
        /// <param name="withZero">Исключить билет, состоящий из нулей. Ведь в реальной жизни такого билета нет.</param>
        /// <returns>Количество счастливых билетов для k*2 значного билета.</returns>
        public double SumRootPowerOptimized(int k, bool withZero)
        {
            double result = 0;
            int limit = k * 9 / 2;
            int remainder = k * 9 % 2;
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(CalculateRoot(k, i), 2);
            }
            result += result;
            for (int i = 0; i <= remainder; i++)
            {
                result += Math.Pow(CalculateRoot(k, limit), 2);
            }
            return withZero ? result : result - 1;
        }

        public double SumRootPowerSpecial(int k, bool withZero) //USELESS FOR NOW.
        {
            double result = 0;
            for (int i = 0; i < k * 9; i++)
            {
                double value = FigureNumber(Convert.ToDouble(k), Convert.ToDouble(i));
                result += Math.Pow(value, 2);
                Console.WriteLine(value);
            }
            return withZero ? result + 1 : result;
        }
    }
}