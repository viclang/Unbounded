using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<double> Add(this Unbounded<double> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<double> Substract(this Unbounded<double> left, Unbounded<double> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<double> Divide(this Unbounded<double> left, Unbounded<double> right)
            => Divide(left, right, (x, y) => x / y);

        [Pure]
        public static Unbounded<double> Multiply(this Unbounded<double> left, Unbounded<double> right)
            => Multiply(left, right, (x, y) => x * y);

        [Pure]
        public static double ToDouble(this Unbounded<double> value) => value.State switch
        {
            UnboundedState.NaN => double.NaN,
            UnboundedState.NegativeInfinity => double.NegativeInfinity,
            UnboundedState.Finite => value.GetFiniteOrDefault(),
            UnboundedState.PositiveInfinity => double.PositiveInfinity,
            _ => throw new InvalidOperationException()
        };
    }
}
