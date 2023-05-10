using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<DateOnly> AddDays(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        [Pure]
        public static Unbounded<DateOnly> AddMonths(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        [Pure]
        public static Unbounded<DateOnly> AddYears(this Unbounded<DateOnly> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        [Pure]
        public static Unbounded<int> Substract(this Unbounded<DateOnly> left, Unbounded<DateOnly> right)
            => Substract(left, right, (x, y) => x.DayNumber - y.DayNumber);
    }
}
