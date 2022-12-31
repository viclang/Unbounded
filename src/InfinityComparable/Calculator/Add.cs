using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<int> Add(this Infinity<int> left, Infinity<int> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<long> Add(this Infinity<long> left, Infinity<long> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<double> Add(this Infinity<double> left, Infinity<double> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<float> Add(this Infinity<float> left, Infinity<float> right)
            => Add(left, right, (x, y) => x + y);

        #region DateTime extensions
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
        #endregion

        #region DateTimeOffset extensions
        public static Infinity<DateTimeOffset> Add(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTimeOffset> AddMilliseconds(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Infinity<DateTimeOffset> AddSeconds(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        public static Infinity<DateTimeOffset> AddMinutes(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<DateTimeOffset> AddHours(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<DateTimeOffset> AddDays(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateTimeOffset> AddMonths(this Infinity<DateTimeOffset> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateTimeOffset> AddYears(this Infinity<DateTimeOffset> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Infinity<DateTimeOffset> AddTicks(this Infinity<DateTimeOffset> left, Infinity<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));
        #endregion

        #region DateOnly extensions
        public static Infinity<DateOnly> AddDays(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateOnly> AddMonths(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateOnly> AddYears(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));
        #endregion

        #region TimeOnly extensions
        public static Infinity<TimeOnly> Add(this Infinity<TimeOnly> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Infinity<TimeOnly> AddMinutes(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<TimeOnly> AddHours(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));
        #endregion

        public static Infinity<TimeSpan> Add(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        private static Infinity<TResult> Add<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(add(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsInfinity) when left.positive == right.positive => new(left.positive),
                (InfinityState.IsInfinity, InfinityState.IsFinite) => new(left.positive),
                (InfinityState.IsFinite, InfinityState.IsInfinity) => new(right.positive),
                _ => new()
            };
    }
}
