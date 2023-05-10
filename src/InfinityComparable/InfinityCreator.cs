namespace UnboundedType
{
    public static partial class Unbounded
    {
        //[Pure]
        //public static Unbounded<T> Inf<T>(T? value = null, bool positive = true) where T : struct, IEquatable<T>, IComparable<T>, IComparable
        //    => value.HasValue ? new(value.Value) : new(positive);

        //[Pure]
        //public static Unbounded<T> Inf<T>(bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
        //    => new(positive);

        //[Pure]
        //public static Unbounded<T> ToInfinity<T>(this T? value, bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
        //    => value.HasValue ? new(value.Value) : new(positive);

        //[Pure]
        //public static Unbounded<T> ToPositiveInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
        //    => value.HasValue ? new(value.Value) : new(true);

        //[Pure]
        //public static Unbounded<T> ToNegativeInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
        //    => value.HasValue ? new(value.Value) : new(false);
    }
}
