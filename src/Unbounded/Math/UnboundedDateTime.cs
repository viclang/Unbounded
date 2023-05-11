using System.Diagnostics.Contracts;

namespace Unbounded
{
    public static partial class Unbounded
    {
        public static Unbounded<DateTime> Add(this Unbounded<DateTime> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Unbounded<DateTime> AddMilliseconds(this Unbounded<DateTime> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Unbounded<DateTime> AddSeconds(this Unbounded<DateTime> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        public static Unbounded<DateTime> AddMinutes(this Unbounded<DateTime> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<DateTime> AddHours(this Unbounded<DateTime> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<DateTime> AddDays(this Unbounded<DateTime> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateTime> AddMonths(this Unbounded<DateTime> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateTime> AddYears(this Unbounded<DateTime> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<DateTime> AddTicks(this Unbounded<DateTime> left, Unbounded<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));

        public static Unbounded<DateTime> Substract(this Unbounded<DateTime> left, Unbounded<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<DateTime> left, Unbounded<DateTime> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
