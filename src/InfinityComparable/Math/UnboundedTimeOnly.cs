using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<TimeOnly> Add(this Unbounded<TimeOnly> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        [Pure]
        public static Unbounded<TimeOnly> AddMinutes(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        [Pure]
        public static Unbounded<TimeOnly> AddHours(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        [Pure]
        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeOnly> left, Unbounded<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
