namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<T> Inf<T>(T? value = null, bool positive = true) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(value, positive);

        public static Infinity<T> Inf<T>(bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(positive);

        public static Infinity<T> ToInfinity<T>(this T? value, bool positive) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(value, positive);

        public static Infinity<T> ToPositiveInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(value, true);

        public static Infinity<T> ToNegativeInfinity<T>(this T? value) where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => new(value, false);
    }
}
