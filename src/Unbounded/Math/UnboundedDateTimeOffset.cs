using System.Diagnostics.Contracts;

namespace Unbounded
{
    public static partial class Unbounded
    {
        public static Unbounded<DateTimeOffset> Add(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Unbounded<DateTimeOffset> AddMilliseconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Unbounded<DateTimeOffset> AddSeconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        public static Unbounded<DateTimeOffset> AddMinutes(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<DateTimeOffset> AddHours(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<DateTimeOffset> AddDays(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateTimeOffset> AddMonths(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateTimeOffset> AddYears(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<DateTimeOffset> AddTicks(this Unbounded<DateTimeOffset> left, Unbounded<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));

        public static Unbounded<DateTimeOffset> Substract(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<DateTimeOffset> left, Unbounded<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
