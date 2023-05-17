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
    }
}
