using System.Globalization;

namespace Unbounded
{
    public static class UnboundedSingle
    {
        public static Unbounded<float> Parse(
            string s,
            NumberStyles style = NumberStyles.AllowThousands | NumberStyles.Float,
            IFormatProvider? provider = null)
            => new(float.Parse(s, style, provider));

        public static bool TryParse(string s, out Unbounded<float>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = float.TryParse(s, out float finite);
                result = new Unbounded<float>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Unbounded<float>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = float.TryParse(s, style, provider, out float finite);
                result = new Unbounded<float>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<float> Add(this Unbounded<float> left, Unbounded<float> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<float> Substract(this Unbounded<float> left, Unbounded<float> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<float> Divide(this Unbounded<float> left, Unbounded<float> right)
            => UnboundedHelper.Divide(left, right, (x, y) => x / y);

        public static Unbounded<float> Multiply(this Unbounded<float> left, Unbounded<float> right)
            => UnboundedHelper.Multiply(left, right, (x, y) => x * y);

        public static float ToFloat(this Unbounded<float> value) => value.State switch
        {
            UnboundedState.NaN => float.NaN,
            UnboundedState.NegativeInfinity => float.NegativeInfinity,
            UnboundedState.Finite => value.GetFiniteOrDefault(),
            UnboundedState.PositiveInfinity => float.PositiveInfinity,
            _ => throw new InvalidOperationException()
        };
    }
}
