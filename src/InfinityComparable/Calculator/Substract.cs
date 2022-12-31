using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<int> Substract(this Infinity<int> left, Infinity<int> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<long> Substract(this Infinity<long> left, Infinity<long> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<double> Substract(this Infinity<double> left, Infinity<double> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<float> Substract(this Infinity<float> left, Infinity<float> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTime> Substract(this Infinity<DateTime> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTime> left, Infinity<DateTime> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateTimeOffset> Substract(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTimeOffset> left, Infinity<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<DateOnly> Substract(this Infinity<DateOnly> left, Infinity<DateOnly> right)
            => Substract(left, right, (x, y) => DateOnly.FromDayNumber(x.DayNumber - y.DayNumber));

        public static Infinity<TimeOnly> Substract(this Infinity<TimeOnly> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));

        public static Infinity<TimeSpan> Substract(this Infinity<TimeOnly> left, Infinity<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x.Add(-y));

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
    }
}
