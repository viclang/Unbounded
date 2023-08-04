using System.Globalization;

namespace Unbounded
{
    public static class UnboundedDecimal
    {
        public static Unbounded<double> Parse(
            string s,
            NumberStyles style = NumberStyles.AllowThousands | NumberStyles.Float,
            IFormatProvider? provider = null)
            => new(double.Parse(s, style, provider));

        public static bool TryParse(string s, out Unbounded<decimal>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = decimal.TryParse(s, out decimal finite);
                result = new Unbounded<decimal>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Unbounded<decimal>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = decimal.TryParse(s, style, provider, out decimal finite);
                result = new Unbounded<decimal>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<decimal> Add(this Unbounded<decimal> left, Unbounded<decimal> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<decimal> Substract(this Unbounded<decimal> left, Unbounded<decimal> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<decimal> Divide(this Unbounded<decimal> left, Unbounded<decimal> right)
            => UnboundedHelper.Divide(left, right, (x, y) => x / y);

        public static Unbounded<decimal> Multiply(this Unbounded<decimal> left, Unbounded<decimal> right)
            => UnboundedHelper.Multiply(left, right, (x, y) => x * y);
    }
}
