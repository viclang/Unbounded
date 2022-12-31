namespace InfinityComparable
{
    public static partial class Infinity
    {
        #region int extensions
        public static Infinity<int> Multiply(this Infinity<int> left, Infinity<int> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<int> Multiply(this Infinity<int> left, int right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<int> Multiply(this int left, Infinity<int> right)
            => Multiply(left, right, (x, y) => x * y);
        #endregion

        #region long extensions
        public static Infinity<long> Multiply(this Infinity<long> left, Infinity<long> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<long> Multiply(this Infinity<long> left, long right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<long> Multiply(this long left, Infinity<long> right)
            => Multiply(left, right, (x, y) => x * y);
        #endregion

        #region double extensions
        public static Infinity<double> Multiply(this Infinity<double> left, Infinity<double> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<double> Multiply(this Infinity<double> left, double right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<double> Multiply(this double left, Infinity<double> right)
            => Multiply(left, right, (x, y) => x * y);
        #endregion

        #region float extensions
        public static Infinity<float> Multiply(this Infinity<float> left, Infinity<float> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<float> Multiply(this Infinity<float> left, float right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<float> Multiply(this float left, Infinity<float> right)
            => Multiply(left, right, (x, y) => x * y);
        #endregion

        private static Infinity<TResult> Multiply<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> multiply)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(multiply(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsFinite) when !right.value.Equals(default) => new(left.positive),
                (InfinityState.IsFinite, InfinityState.IsInfinity) when !left.value.Equals(default) => new(right.positive),
                (InfinityState.IsInfinity, InfinityState.IsInfinity) when left.positive == right.positive => new(true),
                (InfinityState.IsInfinity, InfinityState.IsInfinity) when left.positive != right.positive => new(false),
                _ => new()
            };

        private static Infinity<TResult> Multiply<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            TRight right,
            Func<TLeft, TRight, TResult> multiply)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => left.State switch
            {
                InfinityState.IsFinite => new(multiply(left.value, right)),
                InfinityState.IsInfinity when !right.Equals(default) => new(left.positive),
                _ => new()
            };

        private static Infinity<TResult> Multiply<TLeft, TRight, TResult>(
            TLeft left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> multiply)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => right.State switch
            {
                InfinityState.IsFinite => new(multiply(left, right.value)),
                InfinityState.IsInfinity when !right.Equals(default) => new(right.positive),
                _ => new()
            };
    }
}
