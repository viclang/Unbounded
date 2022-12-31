using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        #region int extensions
        public static Infinity<int> Add(this Infinity<int> left, Infinity<int> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<int> Add(this Infinity<int> left, int right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<int> Add(this int left, Infinity<int> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region long extensions
        public static Infinity<long> Add(this Infinity<long> left, Infinity<long> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<long> Add(this Infinity<long> left, long right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<long> Add(this long left, Infinity<long> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region double extensions
        public static Infinity<double> Add(this Infinity<double> left, Infinity<double> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<double> Add(this Infinity<double> left, double right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<double> Add(this double left, Infinity<double> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region float extensions
        public static Infinity<float> Add(this Infinity<float> left, Infinity<float> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<float> Add(this Infinity<float> left, float right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<float> Add(this float left, Infinity<float> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region DateTime extensions
        public static Infinity<DateTime> Add(this Infinity<DateTime> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTime> Add(this Infinity<DateTime> left, TimeSpan right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTime> Add(this DateTime left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region DateTimeOffset extensions
        public static Infinity<DateTimeOffset> Add(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTimeOffset> Add(this Infinity<DateTimeOffset> left, TimeSpan right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTimeOffset> Add(this DateTimeOffset left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

        #region DateOnly extensions
        public static Infinity<DateOnly> AddDays(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateOnly> AddDays(this Infinity<DateOnly> left, int right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateOnly> AddDays(this DateOnly left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateOnly> AddMonths(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateOnly> AddMonth(this Infinity<DateOnly> left, int right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateOnly> AddMonths(this DateOnly left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateOnly> AddYears(this Infinity<DateOnly> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Infinity<DateOnly> AddYears(this Infinity<DateOnly> left, int right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Infinity<DateOnly> AddYears(this DateOnly left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));
        #endregion

        #region TimeOnly extensions
        public static Infinity<TimeOnly> Add(this Infinity<TimeOnly> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Infinity<TimeOnly> Add(this Infinity<TimeOnly> left, TimeSpan right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Infinity<TimeOnly> Add(this TimeOnly left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Infinity<TimeOnly> AddMinutes(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<TimeOnly> AddMinutes(this Infinity<TimeOnly> left, double right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<TimeOnly> AddMinutes(this TimeOnly left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<TimeOnly> AddHours(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<TimeOnly> AddHours(this Infinity<TimeOnly> left, double right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<TimeOnly> AddHours(this TimeOnly left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));
        #endregion

        #region Timespan extensions
        public static Infinity<TimeSpan> Add(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<TimeSpan> Add(this Infinity<TimeSpan> left, TimeSpan right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<TimeSpan> Add(this TimeSpan left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);
        #endregion

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

        private static Infinity<TResult> Add<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            TRight right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => left.State switch
            {
                InfinityState.IsFinite => new(add(left.value, right)),
                InfinityState.IsInfinity => new(left.positive),
                _ => new()
            };

        private static Infinity<TResult> Add<TLeft, TRight, TResult>(
            TLeft left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => right.State switch
            {
                InfinityState.IsFinite => new(add(left, right.value)),
                InfinityState.IsInfinity => new(right.positive),
                _ => new()
            };
    }
}
