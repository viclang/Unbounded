using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        [Pure]
        public static Infinity<long> Add(this Infinity<long> left, Infinity<long> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Infinity<long> Substract(this Infinity<long> left, Infinity<long> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Infinity<long> Multiply(this Infinity<long> left, Infinity<long> right)
            => Multiply(left, right, (x, y) => x * y);

        [Pure]
        public static Infinity<long> Divide(this Infinity<long> left, Infinity<long> right)
            => Divide(left, right, (x, y) => x / y);
    }
}
