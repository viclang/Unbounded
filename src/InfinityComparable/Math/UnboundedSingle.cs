using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<float> Add(this Unbounded<float> left, Unbounded<float> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<float> Substract(this Unbounded<float> left, Unbounded<float> right)
            => Substract(left, right, (x, y) => x - y);

        [Pure]
        public static Unbounded<float> Divide(this Unbounded<float> left, Unbounded<float> right)
            => Divide(left, right, (x, y) => x / y);

        [Pure]
        public static Unbounded<float> Multiply(this Unbounded<float> left, Unbounded<float> right)
            => Multiply(left, right, (x, y) => x * y);

        [Pure]
        public static float ToFloat(this Unbounded<float> value) => value.State switch
        {
            UnboundedState.NaN => float.NaN,
            UnboundedState.NegativeInfinity => float.NegativeInfinity,
            UnboundedState.Finite => value.GetFiniteOrDefault(),
            UnboundedState.PositiveInfinity => float.PositiveInfinity,
            _ => throw new InvalidOperationException()
        };
    }
}
