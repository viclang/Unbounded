using System.Diagnostics.Contracts;

namespace Unbounded
{
    public static partial class Unbounded
    {
        public static Unbounded<DateOnly> AddDays(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateOnly> AddMonths(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateOnly> AddYears(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<int> Substract(this Unbounded<DateOnly> left, Unbounded<DateOnly> right)
            => Substract(left, right, (x, y) => x.DayNumber - y.DayNumber);
    }
}
