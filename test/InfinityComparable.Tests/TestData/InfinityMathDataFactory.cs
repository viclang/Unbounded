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
                { Unbounded<TLeft>.NegativeInfinity, right, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, right, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, default(TRight), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, default(TRight), Unbounded<TResult>.PositiveInfinity },
                { left, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { left, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { default(TLeft), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { default(TLeft), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity , Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
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
                { Unbounded<TLeft>.NegativeInfinity, right, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, right, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, default(TRight), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, default(TRight), Unbounded<TResult>.PositiveInfinity },
                { left, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { left, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { default(TLeft), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { default(TLeft), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
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
                //{ left, right, result },
                //{ Unbounded<TLeft>.NegativeInfinity, right, Unbounded<TResult>.NegativeInfinity },
                //{ Unbounded<TLeft>.PositiveInfinity, right, Unbounded<TResult>.PositiveInfinity },
                //{ Unbounded<TLeft>.NegativeInfinity, default(TRight), Unbounded<TResult>.NaN },
                //{ Unbounded<TLeft>.PositiveInfinity, default(TRight), Unbounded<TResult>.NaN },
                //{ left, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { left, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { default(TLeft), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { default(TLeft), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateDivideData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { left, right, result },
                { Unbounded<TLeft>.NegativeInfinity, right, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, right, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, default(TRight), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, default(TRight), Unbounded<TResult>.PositiveInfinity },
                { left, Unbounded<TRight>.NegativeInfinity, default(TResult) },
                { left, Unbounded<TRight>.PositiveInfinity, default(TResult) },
                { default(TLeft), Unbounded<TRight>.NegativeInfinity, default(TResult) },
                { default(TLeft), Unbounded<TRight>.PositiveInfinity, default(TResult) },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
            };
    }
}
