namespace HappyTickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SmartSolutions : AbstractSolution<SmartSolutions>
    {
        private readonly List<List<long>> _speedTable = new();

        internal SmartSolutions()
        {
            this._speedTable.Insert(0, Enumerable.Range(0, 10).Select(e => (long)e).ToList());
            this._speedTable.Insert(1, Enumerable.Range(1, 10).Select(e => (long)e).ToList());
            this._speedTable[1].AddRange(Enumerable.Range(0, 10).Reverse().Select(e => (long)e));
        }

        /// <summary>
        /// Вычисляет количество счастливых билетов методом фигурных чисел.
        /// </summary>
        internal SmartSolutions CalculateUnoptimally()
        {
            int comparedPartsLength = this.DigitsCount / 2;
            double result = 0;
            for (int i = 0; i <= comparedPartsLength * 9; i++)
            {
                result += Math.Pow(this.CalculateRoot(comparedPartsLength, i), 2);
            }

            if (this.DigitsCount % 2 == 1)
            {
                result *= 10;
            }

            this.Result = this.CalculateWithZeroTicket ? result : result - 1;
            return this;
        }

        /// <summary>
        /// Вычисляет количество счастливых билетов методом фигурных чисел. Оптимизированный метод.
        /// </summary>
        public SmartSolutions CalculateOptimally()
        {
            int comparedPartsLength = this.DigitsCount / 2;
            double result = 0;
            int limit = comparedPartsLength * 9 / 2;
            for (int i = 0; i < limit; i++)
            {
                result += Math.Pow(this.CalculateRoot(comparedPartsLength, i), 2);
            }

            result += result;
            for (int i = 0; i <= comparedPartsLength % 2; i++)
            {
                result += Math.Pow(this.CalculateRoot(comparedPartsLength, limit), 2);
            }

            if (this.DigitsCount % 2 == 1)
            {
                result *= 10;
            }

            this.Result = this.CalculateWithZeroTicket ? result : result - 1;
            return this;
        }

        /// <summary>
        /// Функция F(k, i), вычисляющая корень из суммы счастливых билетов, равных i.
        /// </summary>
        /// <param name="comparedPartsLength">Длина сравниваемой части.</param>
        /// <param name="comparedPartsSum">Сумма цифр сравниваемой части.</param>
        /// <returns>Корень суммы счастливых билетов, равных сумме цифр сравниваемых частей.</returns>
        private long CalculateRoot(int comparedPartsLength, int comparedPartsSum)
        {
            if (comparedPartsLength < 2)
            {
                return 1;
            }

            if (comparedPartsSum < 0)
            {
                return 0;
            }

            if (comparedPartsSum == 0)
            {
                this.AddToTable(comparedPartsLength, comparedPartsSum, 1);
                return 1;
            }

            long previousRoot = this._speedTable.HasElementAtIndexesOf(comparedPartsLength - 1, comparedPartsSum - 1)
                ? this._speedTable[comparedPartsLength - 1][comparedPartsSum - 1]
                : this.CalculateRoot(comparedPartsLength, comparedPartsSum - 1);

            long rootDiff = this.CalculateRootDifference(comparedPartsLength, comparedPartsSum);
            long result = previousRoot + rootDiff;
            this.AddToTable(comparedPartsLength, comparedPartsSum, result);
            return result;
        }

        /// <summary>
        /// Добавляет в таблицу найденных значений значение.
        /// </summary>
        /// <param name="comparedPartsLength">Длина сравниваемой части.</param>
        /// <param name="comparedPartsSum">Сумма цифр сравниваемой части.</param>
        /// <param name="value">Значение.</param>
        private void AddToTable(int comparedPartsLength, int comparedPartsSum, long value)
        {
            if (this._speedTable.Count <= --comparedPartsLength)
            {
                this._speedTable.AddRange(
                    Enumerable
                        .Range(this._speedTable.Count, comparedPartsLength)
                        .Select(e => new List<long>())
                    );
            }

            if (this._speedTable.HasElementAtIndexesOf(comparedPartsLength, comparedPartsSum)
                && this._speedTable[comparedPartsLength][comparedPartsSum] > 0
            )
            {
                return;
            }

            this._speedTable[comparedPartsLength].Insert(comparedPartsSum, value);
        }

        /// <summary>
        /// Вычисляет разницу между корнями для сравниваемых чисел заданной длины и суммы цифр.
        /// </summary>
        /// <param name="comparedPartsLength">Длина сравниваемой части.</param>
        /// <param name="comparedPartsSum">Сумма цифр сравниваемой части.</param>
        /// <returns>Разница между корнями.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")]
        private long CalculateRootDifference(int comparedPartsLength, int comparedPartsSum)
        {
            if (comparedPartsLength != 2)
            {
                long previousFigureNumber = this._speedTable.HasElementAtIndexesOf(comparedPartsLength - 2, comparedPartsSum)
                        ? this._speedTable[comparedPartsLength - 2][comparedPartsSum]
                        : this.CalculateRoot(comparedPartsLength - 1, comparedPartsSum);

                long coefficient = this._speedTable.HasElementAtIndexesOf(comparedPartsLength - 2, comparedPartsSum - 10)
                    ? this._speedTable[comparedPartsLength - 2][comparedPartsSum - 10]
                    : this.CalculateRoot(comparedPartsLength - 1, comparedPartsSum - 10);

                return previousFigureNumber - coefficient;
            }

            if (comparedPartsSum is >= 10 and <= 19)
            {
                return -1;
            }

            return comparedPartsSum <= 9 ? 1 : 0;
        }

        #region Future part
        public double SumRootPowerSpecial(int n, bool withZero)
        {
            double result = 0;
            for (int i = 0; i < n * 9; i++)
            {
                double value = this.FigureNumber(Convert.ToDouble(n), Convert.ToDouble(i));
                result += Math.Pow(value, 2);
                Console.WriteLine(value);
            }

            return withZero ? result + 1 : result;
        }

        private double FigureNumber(double k, double i) =>
            k != 1
                ? (i + k - 1) / (k - 1) * this.FigureNumber(k - 1, i)
                : 1;
        #endregion
    }
}