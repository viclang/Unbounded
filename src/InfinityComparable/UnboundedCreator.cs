using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<double> DoubleToUnbounded(this double value)
        {
            if (double.IsFinite(value))
            {
                return value;
            }
            if (double.IsNegativeInfinity(value))
            {
                return Unbounded<double>.NegativeInfinity;
            }
            if (double.IsPositiveInfinity(value))
            {
                return Unbounded<double>.PositiveInfinity;
            }
            return Unbounded<double>.NaN;
        }

        [Pure]
        public static Unbounded<float> FloatToUnbounded(this float value)
        {
            if (float.IsFinite(value))
            {
                return value;
            }
            if (float.IsNegativeInfinity(value))
            {
                return Unbounded<float>.NegativeInfinity;
            }
            if (float.IsPositiveInfinity(value))
            {
                return Unbounded<float>.PositiveInfinity;
            }
            return Unbounded<float>.NaN;
        }

        [Pure]
        public static Unbounded<T> ToUnbounded<T>(this T? value, UnboundedState state) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(state);

        [Pure]
        public static Unbounded<T> ToPositiveInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(UnboundedState.PositiveInfinity);

        [Pure]
        public static Unbounded<T> ToNegativeInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(UnboundedState.NegativeInfinity);
    }
}
