using System.Globalization;

namespace Unbounded
{
    public static class UnboundedDouble
    {
        public static Unbounded<double> Parse(
            string s,
            NumberStyles style = NumberStyles.AllowThousands | NumberStyles.Float,
            IFormatProvider? provider = null)
            => new(double.Parse(s, style, provider));

        public static bool TryParse(string s, out Unbounded<double>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = double.TryParse(s, out double finite);
                result = new Unbounded<double>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Unbounded<double>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = double.TryParse(s, style, provider, out double finite);
                result = new Unbounded<double>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<double> Add(this Unbounded<double> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<double> Substract(this Unbounded<double> left, Unbounded<double> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<double> Divide(this Unbounded<double> left, Unbounded<double> right)
            => UnboundedHelper.Divide(left, right, (x, y) => x / y);

        public static Unbounded<double> Multiply(this Unbounded<double> left, Unbounded<double> right)
            => UnboundedHelper.Multiply(left, right, (x, y) => x * y);

        public static double ToDouble(this Unbounded<double> value) => value.State switch
        {
            UnboundedState.NaN => double.NaN,
            UnboundedState.NegativeInfinity => double.NegativeInfinity,
            UnboundedState.Finite => value.GetFiniteOrDefault(),
            UnboundedState.PositiveInfinity => double.PositiveInfinity,
            _ => throw new InvalidOperationException()
        };
    }
}
