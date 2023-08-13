namespace Unbounded.Tests.Factories
{
    public static class UnboundedMathDataFactory
    {
        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateAddData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>
            => new()
            {
                { new(left) , new(right), new(result) },
                { Unbounded<TLeft>.NegativeInfinity, new(right), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(right), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, new(default(TRight)), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(default(TRight)), Unbounded<TResult>.PositiveInfinity },
                { new(left), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { new(left), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { new(default(TLeft)), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { new(default(TLeft)), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity , Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateSubstractData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>
            => new()
            {
                { new(left), new(right), new(result) },
                { Unbounded<TLeft>.NegativeInfinity, new(right), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(right), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, new(default(TRight)), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(default(TRight)), Unbounded<TResult>.PositiveInfinity },
                { new(left), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { new(left), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { new(default(TLeft)), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { new(default(TLeft)), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateMultiplyData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>
            => new()
            {
                { new(left), new(right), new(result) },
                { Unbounded<TLeft>.NegativeInfinity, new(right), Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(right), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, new(default(TRight)), Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, new(default(TRight)), Unbounded<TResult>.NaN },
                { new(left), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
                { new(left), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { new(default(TLeft)), Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { new(default(TLeft)), Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NegativeInfinity },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NegativeInfinity },
            };

        public static TheoryData<Unbounded<TLeft>, Unbounded<TRight>, Unbounded<TResult>> CreateDivideData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>
            => new()
            {
                { new(left), new(right), new(result) },
                { Unbounded<TLeft>.NegativeInfinity, new(right), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(right), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.NegativeInfinity, new(default(TRight)), Unbounded<TResult>.PositiveInfinity },
                { Unbounded<TLeft>.PositiveInfinity, new(default(TRight)), Unbounded<TResult>.PositiveInfinity },
                { new(left), Unbounded<TRight>.NegativeInfinity, new(default(TResult)) },
                { new(left), Unbounded<TRight>.PositiveInfinity, new(default(TResult)) },
                { new(default(TLeft)), Unbounded<TRight>.NegativeInfinity, new(default(TResult)) },
                { new(default(TLeft)), Unbounded<TRight>.PositiveInfinity, new(default(TResult)) },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.NegativeInfinity, Unbounded<TRight>.PositiveInfinity, Unbounded<TResult>.NaN },
                { Unbounded<TLeft>.PositiveInfinity, Unbounded<TRight>.NegativeInfinity, Unbounded<TResult>.NaN },
            };
    }
}
