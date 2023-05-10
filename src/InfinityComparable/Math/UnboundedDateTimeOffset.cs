using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<DateTimeOffset> Add(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<DateTimeOffset> AddMilliseconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddSeconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddMinutes(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddHours(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddDays(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddMonths(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddYears(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        [Pure]
        public static Unbounded<DateTimeOffset> AddTicks(this Unbounded<DateTimeOffset> left, Unbounded<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));

        [Pure]
        public static Unbounded<DateTimeOffset> Substract(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<TimeSpan> Substract(this Unbounded<DateTimeOffset> left, Unbounded<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
