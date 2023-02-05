using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        private static Infinity<TResult> Add<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(add(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsInfinity) when left.positive == right.positive => new(left.positive),
                (InfinityState.IsInfinity, InfinityState.IsFinite) => new(left.positive),
                (InfinityState.IsFinite, InfinityState.IsInfinity) => new(right.positive),
                _ => new()
            };

        private static Infinity<TResult> Substract<TLeft, TRight, TResult>(
            Infinity<TLeft> left,
            Infinity<TRight> right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => (left.State, right.State) switch
            {
                (InfinityState.IsFinite, InfinityState.IsFinite) => new(substract(left.value, right.value)),
                (InfinityState.IsInfinity, InfinityState.IsFinite) => new(left.positive),
                (InfinityState.IsFinite, InfinityState.IsInfinity) => new(right.positive),
                _ => new()
            };

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
