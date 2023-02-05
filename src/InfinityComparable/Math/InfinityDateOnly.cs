using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        [Pure]
        public static Infinity<DateOnly> AddDays(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        [Pure]
        public static Infinity<DateOnly> AddMonths(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        [Pure]
        public static Infinity<DateOnly> AddYears(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        [Pure]
        public static Infinity<int> Substract(this Infinity<DateOnly> left, Infinity<DateOnly> right)
            => Substract(left, right, (x, y) => x.DayNumber - y.DayNumber);
    }
}
