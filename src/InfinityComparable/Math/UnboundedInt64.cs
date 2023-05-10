using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<long> Add(this Unbounded<long> left, Unbounded<long> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<long> Substract(this Unbounded<long> left, Unbounded<long> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<long> Multiply(this Unbounded<long> left, Unbounded<long> right)
            => Multiply(left, right, (x, y) => x * y);

        [Pure]
        public static Unbounded<long> Divide(this Unbounded<long> left, Unbounded<long> right)
            => Divide(left, right, (x, y) => x / y);
    }
}
