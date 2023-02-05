using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        [Pure]
        public static Infinity<T> Inf<T>(T? value = null, bool positive = true) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(positive);

        [Pure]
        public static Infinity<T> Inf<T>(bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(positive);

        [Pure]
        public static Infinity<T> ToInfinity<T>(this T? value, bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(positive);

        [Pure]
        public static Infinity<T> ToPositiveInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(true);

        [Pure]
        public static Infinity<T> ToNegativeInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => value.HasValue ? new(value.Value) : new(false);
    }
}
