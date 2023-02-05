using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        [Pure]
        public static Infinity<TimeSpan> Add(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Infinity<TimeSpan> Substract(this Infinity<TimeSpan> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
