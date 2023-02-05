﻿namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<DateTime> Add(this Infinity<DateTime> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTime> AddMilliseconds(this Infinity<DateTime> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Infinity<DateTime> AddSeconds(this Infinity<DateTime> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        public static Infinity<DateTime> AddMinutes(this Infinity<DateTime> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<DateTime> AddHours(this Infinity<DateTime> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<DateTime> AddDays(this Infinity<DateTime> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateTime> AddMonths(this Infinity<DateTime> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateTime> AddYears(this Infinity<DateTime> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Infinity<DateTime> AddTicks(this Infinity<DateTime> left, Infinity<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));

        public static Infinity<DateTime> Substract(this Infinity<DateTime> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTime> left, Infinity<DateTime> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
