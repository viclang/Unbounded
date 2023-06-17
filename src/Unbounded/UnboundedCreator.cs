namespace Unbounded
{
    public static partial class UnboundedExtensions
    {
        public static Unbounded<T> ToUnbounded<T>(this T? value, UnboundedState state) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(state);

        public static Unbounded<T> ToPositiveInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : Unbounded<T>.PositiveInfinity;

        public static Unbounded<T> ToNegativeInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : Unbounded<T>.NegativeInfinity;

        public static Unbounded<T> ToNaN<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : Unbounded<T>.NaN;

        public static Unbounded<float> ToUnbounded(this float value)
        {
            if (float.IsFinite(value))
            {
                return new(value);
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

        public static Unbounded<double> ToUnbounded(this double value)
        {
            if (double.IsFinite(value))
            {
                return new(value);
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
    }
}
