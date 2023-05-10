using UnboundedType;

namespace UnboundedType.Tests.Factories
{
    public static class InfinityMathDataFactory
    {
        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateAddData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { left, right, result },
                { UnboundedState.NegativeInfinity, right, UnboundedState.NegativeInfinity },
                { UnboundedState.PositiveInfinity, right, UnboundedState.PositiveInfinity },
                { UnboundedState.NegativeInfinity, default(TRight), UnboundedState.NegativeInfinity },
                { UnboundedState.PositiveInfinity, default(TRight), UnboundedState.PositiveInfinity },
                { left, UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity },
                { left, UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity },
                { default(TLeft), UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity },
                { default(TLeft), UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity },
                { UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity },
                { UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity },
                { UnboundedState.NegativeInfinity, UnboundedState.PositiveInfinity , UnboundedState.NaN },
                { UnboundedState.PositiveInfinity, UnboundedState.NegativeInfinity, UnboundedState.NaN },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateSubstractData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { left, right, result },
                { UnboundedState.NegativeInfinity, right, UnboundedState.NegativeInfinity },
                { UnboundedState.PositiveInfinity, right, UnboundedState.PositiveInfinity },
                { UnboundedState.NegativeInfinity, default(TRight), UnboundedState.NegativeInfinity },
                { UnboundedState.PositiveInfinity, default(TRight), UnboundedState.PositiveInfinity },
                { left, UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity },
                { left, UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity },
                { default(TLeft), UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity },
                { default(TLeft), UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity },
                { UnboundedState.PositiveInfinity, UnboundedState.PositiveInfinity, UnboundedState.NaN },
                { UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity, UnboundedState.NaN },
                { UnboundedState.NegativeInfinity, UnboundedState.PositiveInfinity, UnboundedState.NaN },
                { UnboundedState.PositiveInfinity, UnboundedState.NegativeInfinity, UnboundedState.NaN },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateMultiplyData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity }
                //{ new(left), new(right), new(result) },
                //{ new(false), new(right), new(false) },
                //{ new(true), new(right), new(true) },
                //{ new(false), new(default(TRight)), new() },
                //{ new(true), new(default(TRight)), new() },
                //{ new(left), new(false), new(false) },
                //{ new(left), new(true), new(true) },
                //{ new(default(TLeft)), new(false), new() },
                //{ new(default(TLeft)), new(true), new() },
                //{ new(true), new(true), new(true) },
                //{ new(false), new(false), new(true) },
                //{ new(false), new(true), new(false) },
                //{ new(true), new(false), new(false) },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateDivideData<TLeft, TRight, TResult>(
            TLeft left,
            TRight Right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity, UnboundedState.NegativeInfinity }
                //{ new(left), new(Right), new(result) },
                //{ new(false), new(Right), new(true) },
                //{ new(true), new(Right), new(true) },
                //{ new(false), new(default(TRight)), new(true) },
                //{ new(true), new(default(TRight)), new(true) },
                //{ new(left), new(false), new(default(TResult)) },
                //{ new(left), new(true), new(default(TResult)) },
                //{ new(default(TLeft)), new(false), new(default(TResult)) },
                //{ new(default(TLeft)), new(true), new(default(TResult)) },
                //{ new(true), new(true), new() },
                //{ new(false), new(false), new() },
                //{ new(false), new(true), new() },
                //{ new(true), new(false), new() },
            };
    }
}
