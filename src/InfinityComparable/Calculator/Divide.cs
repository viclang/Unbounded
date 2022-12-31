namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<int> Divide(this Infinity<int> left, Infinity<int> right)
            => Divide(left, right, (x, y) => x / y);

        public static Infinity<long> Divide(this Infinity<long> left, Infinity<long> right)
            => Divide(left, right, (x, y) => x / y);

        public static Infinity<double> Divide(this Infinity<double> left, Infinity<double> right)
            => Divide(left, right, (x, y) => x / y);

        public static Infinity<float> Divide(this Infinity<float> left, Infinity<float> right)
            => Divide(left, right, (x, y) => x / y);

        private static Infinity<TResult> Divide<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> divide)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(divide(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsFinite) => new(true),
                (InfinityState.IsFinite, InfinityState.IsInfinity) => new(default(TResult)),
                _ => new()
            };
    }
}
