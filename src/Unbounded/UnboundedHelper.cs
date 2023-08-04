namespace Unbounded
{
    internal static class UnboundedHelper
    {
        internal static bool TryParseUnbounded<T>(string s, out Unbounded<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
        {
            if (string.IsNullOrWhiteSpace(s) || s.Equals("NaN"))
            {
                result = Unbounded<T>.NaN;
                return true;
            }
            if (s.Equals("-Infinity") || s.Equals("-∞"))
            {
                result = Unbounded<T>.NegativeInfinity;
                return true;
            }
            if (s.Equals("Infinity") || s.Equals("+∞") || s.Equals("∞"))
            {
                result = Unbounded<T>.PositiveInfinity;
                return true;
            }
            result = null;
            return false;
        }

        internal static Unbounded<TResult> Add<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
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

        internal static Unbounded<TResult> Substract<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
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

        internal static Unbounded<TResult> Multiply<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> multiply)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return new(multiply(left.GetFiniteOrDefault(), right.GetFiniteOrDefault()));
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
                    return Unbounded<TResult>.PositiveInfinity;
                }
                return Unbounded<TResult>.NegativeInfinity;
            }
            return Unbounded<TResult>.NaN;
        }

        internal static Unbounded<TResult> Divide<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> divide)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return new(divide(left.GetFiniteOrDefault(), right.GetFiniteOrDefault()));
            }

            if (left.IsInfinity && right.IsFinite)
            {
                return Unbounded<TResult>.PositiveInfinity;
            }

            if (left.IsFinite && right.IsInfinity)
            {
                return new(default(TResult));
            }

            return Unbounded<TResult>.NaN;
        }
    }
}
