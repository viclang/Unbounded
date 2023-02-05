using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        [Pure]
        public static Infinity<int> Add(this Infinity<int> left, Infinity<int> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Infinity<int> Substract(this Infinity<int> left, Infinity<int> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Infinity<int> Divide(this Infinity<int> left, Infinity<int> right)
            => Divide(left, right, (x, y) => x / y);

        [Pure]
        public static Infinity<int> Multiply(this Infinity<int> left, Infinity<int> right)
            => Multiply(left, right, (x, y) => x * y);
    }
}
