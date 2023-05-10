using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<decimal> Add(this Unbounded<decimal> left, Unbounded<decimal> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<decimal> Substract(this Unbounded<decimal> left, Unbounded<decimal> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<decimal> Divide(this Unbounded<decimal> left, Unbounded<decimal> right)
            => Divide(left, right, (x, y) => x / y);

        [Pure]
        public static Unbounded<decimal> Multiply(this Unbounded<decimal> left, Unbounded<decimal> right)
            => Multiply(left, right, (x, y) => x * y);
    }
}
