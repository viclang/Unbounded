using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<int> Add(this Unbounded<int> left, Unbounded<int> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<int> Substract(this Unbounded<int> left, Unbounded<int> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<int> Divide(this Unbounded<int> left, Unbounded<int> right)
            => Divide(left, right, (x, y) => x / y);

        [Pure]
        public static Unbounded<int> Multiply(this Unbounded<int> left, Unbounded<int> right)
            => Multiply(left, right, (x, y) => x * y);
    }
}
