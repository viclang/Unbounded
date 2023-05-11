namespace Unbounded
{
    public enum UnboundedState : byte
    {
        NaN = 0,
        NegativeInfinity = 1,
        Finite = 2,
        PositiveInfinity = 3,
    }

    public static partial class UnboundedExtensions
    {
        internal static bool TryGetUnboundedState<T>(this T value, out UnboundedState unboundedState)
        {
            if (value is double doubleValue)
            {
                return TryGetUnboundedState(doubleValue, out unboundedState);
            }

            if (value is float floatValue)
            {
                return TryGetUnboundedState(floatValue, out unboundedState);
            }
            unboundedState = UnboundedState.Finite;
            return false;
        }

        private static bool TryGetUnboundedState(double value, out UnboundedState unboundedState)
        {
            if (double.IsFinite(value))
            {
                unboundedState = UnboundedState.Finite;
                return false;
            }

            if (double.IsNegativeInfinity(value))
            {
                unboundedState = UnboundedState.NegativeInfinity;
                return true;
            }

            if (double.IsPositiveInfinity(value))
            {
                unboundedState = UnboundedState.PositiveInfinity;
                return true;
            }

            unboundedState = UnboundedState.NaN;
            return true;
        }

        private static bool TryGetUnboundedState(float value, out UnboundedState unboundedState)
        {
            if (float.IsFinite(value))
            {
                unboundedState = UnboundedState.Finite;
                return false;
            }

            if (float.IsNegativeInfinity(value))
            {
                unboundedState = UnboundedState.NegativeInfinity;
                return true;
            }

            if (float.IsPositiveInfinity(value))
            {
                unboundedState = UnboundedState.PositiveInfinity;
                return true;
            }

            unboundedState = UnboundedState.NaN;
            return true;
        }
    }
}
