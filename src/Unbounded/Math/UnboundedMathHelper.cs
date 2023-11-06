using System.Numerics;

namespace Unbounded;

public static class UnboundedMathHelper
{
    public static Unbounded<T> Add<T>(
        this Unbounded<T> left,
        Unbounded<T> right)
    where T : struct, IEquatable<T>, IComparable<T>, IParsable<T>, ISpanParsable<T>, IAdditionOperators<T, T, T>
    {
        return Add(left, right, (x, y) => x + y);
    }

    internal static Unbounded<TResult> Add<TLeft, TRight, TResult>(
        Unbounded<TLeft> left,
        Unbounded<TRight> right,
        Func<TLeft, TRight, TResult> add)
    where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IParsable<TLeft>, ISpanParsable<TLeft>
    where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IParsable<TRight>, ISpanParsable<TRight>
    where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IParsable<TResult>, ISpanParsable<TResult>
    {
        if (left.IsFinite && right.IsFinite)
        {
            return new(add(left.GetFiniteOrDefault(), right.GetFiniteOrDefault()));
        }
        if (left.IsInfinity && right.IsInfinity && left.IsPositiveInfinity == right.IsPositiveInfinity)
        {
            return new(left.State);
        }
        if (left.IsInfinity && right.IsFinite)
        {
            return new(left.State);
        }
        if (left.IsFinite && right.IsInfinity)
        {
            return new(right.State);
        }
        return Unbounded<TResult>.NaN;
    }

    public static Unbounded<T> Substract<T>(
        this Unbounded<T> left,
        Unbounded<T> right)
    where T : struct, IEquatable<T>, IComparable<T>, IParsable<T>, ISpanParsable<T>, ISubtractionOperators<T, T, T>
    {
        return Substract(left, right, (x, y) => x - y);
    }

    internal static Unbounded<TResult> Substract<TLeft, TRight, TResult>(
        Unbounded<TLeft> left,
        Unbounded<TRight> right,
        Func<TLeft, TRight, TResult> substract)
    where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IParsable<TLeft>, ISpanParsable<TLeft>
    where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IParsable<TRight>, ISpanParsable<TRight>
    where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IParsable<TResult>, ISpanParsable<TResult>
    {
        if (left.IsFinite && right.IsFinite)
        {
            return new(substract(left.GetFiniteOrDefault(), right.GetFiniteOrDefault()));
        }
        if (left.IsInfinity && right.IsFinite)
        {
            return new(left.State);
        }
        if (left.IsFinite && right.IsInfinity)
        {
            return new(right.State);
        }
        return new(UnboundedState.NaN);
    }

    public static Unbounded<T> Multiply<T>(
        this Unbounded<T> left,
        Unbounded<T> right)
    where T : struct, IEquatable<T>, IComparable<T>, IParsable<T>, ISpanParsable<T>, IMultiplyOperators<T, T, T>
    {
        if (left.IsFinite && right.IsFinite)
        {
            return new(left.GetFiniteOrDefault() * right.GetFiniteOrDefault());
        }
        if (left.IsInfinity && right.IsFinite && !right.GetFiniteOrDefault().Equals(default))
        {
            return new(left.State);
        }
        if (left.IsFinite && right.IsInfinity && !left.GetFiniteOrDefault().Equals(default))
        {
            return new(right.State);
        }
        if (left.IsInfinity && right.IsInfinity)
        {
            if (left.IsPositiveInfinity == right.IsPositiveInfinity)
            {
                return Unbounded<T>.PositiveInfinity;
            }
            return Unbounded<T>.NegativeInfinity;
        }
        return Unbounded<T>.NaN;
    }

    public static Unbounded<T> Divide<T>(
        this Unbounded<T> left,
        Unbounded<T> right)
    where T : struct, IEquatable<T>, IComparable<T>, IParsable<T>, ISpanParsable<T>, INumberBase<T>
    {
        if (left.IsFinite && right.IsFinite)
        {
            return new(left.GetFiniteOrDefault() / right.GetFiniteOrDefault());
        }
        if (left.IsInfinity && right.IsFinite)
        {
            return Unbounded<T>.PositiveInfinity;
        }
        if (left.IsFinite && right.IsInfinity)
        {
            return new(T.Zero);
        }
        return Unbounded<T>.NaN;
    }
}
