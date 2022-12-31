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
        public static Infinity<int> Substract(this Infinity<int> left, Infinity<int> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<int> Substract(this Infinity<int> left, int right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<int> Substract(this int left, Infinity<int> right)
            => Substract(left, right, (x, y) => x - y);
        #endregion

        #region long extensions
        public static Infinity<long> Substract(this Infinity<long> left, Infinity<long> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<double> Substract(this Infinity<double> left, double right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<float> Substract(this float left, Infinity<float> right)
            => Substract(left, right, (x, y) => x - y);
        #endregion

        #region DateTime extensions
        public static Infinity<DateTime> Substract(this Infinity<DateTime> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTime> Substract(this Infinity<DateTime> left, TimeSpan right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTime> Substract(this DateTime left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);


        public static Infinity<TimeSpan> Substract(this Infinity<DateTime> left, Infinity<DateTime> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTime> left, DateTime right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this DateTime left, Infinity<DateTime> right)
            => Substract(left, right, (x, y) => x - y);
        #endregion

        #region DateTimeOffset extensions
        public static Infinity<DateTimeOffset> Substract(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTimeOffset> Substract(this Infinity<DateTimeOffset> left, TimeSpan right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTimeOffset> Substract(this DateTimeOffset left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);


        public static Infinity<TimeSpan> Substract(this Infinity<DateTimeOffset> left, Infinity<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTimeOffset> left, DateTimeOffset right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this DateTimeOffset left, Infinity<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);
        #endregion

        #region DateOnly extensions
        public static Infinity<DateOnly> Substract(this Infinity<DateOnly> left, Infinity<DateOnly> right)
            => Substract(left, right, (x, y) => DateOnly.FromDayNumber(x.DayNumber - y.DayNumber));

        public static Infinity<DateOnly> Substract(this Infinity<DateOnly> left, DateOnly right)
            => Substract(left, right, (x, y) => DateOnly.FromDayNumber(x.DayNumber - y.DayNumber));

        public static Infinity<DateOnly> Substract(this DateOnly left, Infinity<DateOnly> right)
            => Substract(left, right, (x, y) => DateOnly.FromDayNumber(x.DayNumber - y.DayNumber));
        #endregion

        #region TimeOnly extensions
        public static Infinity<TimeOnly> Substract(this Infinity<TimeOnly> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));

        public static Infinity<TimeOnly> Substract(this Infinity<TimeOnly> left, TimeSpan right)
            => Substract(left, right, (x, y) => x.Add(-y));

        public static Infinity<TimeOnly> Substract(this TimeOnly left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));


        public static Infinity<TimeSpan> Substract(this Infinity<TimeOnly> left, Infinity<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);
        public static Infinity<TimeSpan> Substract(this Infinity<TimeOnly> left, TimeOnly right)
            => Substract(left, right, (x, y) => x - y);
        public static Infinity<TimeSpan> Substract(this TimeOnly left, Infinity<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);
        #endregion

        #region TimeSpan extensions
        public static Infinity<TimeSpan> Substract(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));

        public static Infinity<TimeSpan> Substract(this Infinity<TimeSpan> left, TimeSpan right)
            => Substract(left, right, (x, y) => x.Add(-y));

        public static Infinity<TimeSpan> Substract(this TimeSpan left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));
        #endregion

        private static Infinity<TResult> Substract<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(substract(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsFinite) => new(left.positive),
                (InfinityState.IsFinite, InfinityState.IsInfinity) => new(right.positive),
                _ => new()
            };

        private static Infinity<TResult> Substract<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            TRight right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => left.State switch
            {
                InfinityState.IsFinite => new(substract(left.value, right)),
                InfinityState.IsInfinity => new(left.positive),
                _ => new()
            };

        private static Infinity<TResult> Substract<TLeft, TRight, TResult>(
            TLeft left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => right.State switch
            {
                InfinityState.IsFinite => new(substract(left, right.value)),
                InfinityState.IsInfinity => new(right.positive),
                _ => new()
            };
    }
}
