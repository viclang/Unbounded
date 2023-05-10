namespace UnboundedType
{
    public static partial class Unbounded
    {
        private static Unbounded<TResult> Add<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> add)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return add(left.GetFiniteOrDefault(), right.GetFiniteOrDefault());
            }

            if (left.IsInfinity && right.IsInfinity && left.IsPositiveInfinity == right.IsPositiveInfinity)
            {
                return left.State;
            }

            if (left.IsInfinity && right.IsFinite)
            {
                return left.State;
            }

            if (left.IsFinite && right.IsInfinity)
            {
                return right.State;
            }

            return UnboundedState.NaN;
        }

        private static Unbounded<TResult> Substract<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> substract)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return substract(left.GetFiniteOrDefault(), right.GetFiniteOrDefault());
            }

            if (left.IsInfinity && right.IsFinite)
            {
                return left.State;
            }

            if (left.IsFinite && right.IsInfinity)
            {
                return right.State;
            }

            return UnboundedState.NaN;
        }

        private static Unbounded<TResult> Multiply<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> multiply)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return multiply(left.GetFiniteOrDefault(), right.GetFiniteOrDefault());
            }

            if (left.IsInfinity && right.IsFinite && !right.GetFiniteOrDefault().Equals(default))
            {
                return left.State;
            }

            if (left.IsFinite && right.IsInfinity && !left.GetFiniteOrDefault().Equals(default))
            {
                return left.State;
            }

            if (left.IsInfinity && right.IsInfinity)
            {
                if (left.IsPositiveInfinity == right.IsPositiveInfinity)
                {
                    return UnboundedState.PositiveInfinity;
                }
                return UnboundedState.NegativeInfinity;
            }
            return UnboundedState.NaN;
        }

        private static Unbounded<TResult> Divide<TLeft, TRight, TResult>(
            Unbounded<TLeft> left,
            Unbounded<TRight> right,
            Func<TLeft, TRight, TResult> divide)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (left.IsFinite && right.IsFinite)
            {
                return divide(left.GetFiniteOrDefault(), right.GetFiniteOrDefault());
            }

            if (left.IsInfinity && right.IsFinite)
            {
                return UnboundedState.PositiveInfinity;
            }

            if (left.IsFinite && right.IsInfinity)
            {
                return default(TResult);
            }

            return UnboundedState.NaN;
        }
    }
}
