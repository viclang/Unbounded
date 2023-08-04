using System.Globalization;

namespace Unbounded
{
    public static class UnboundedInt64
    {
        public static Unbounded<long> Parse(
            string s,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider? provider = null)
            => new(long.Parse(s, style, provider));

        public static bool TryParse(string s, out Unbounded<long>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = long.TryParse(s, out long finite);
                result = new Unbounded<long>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Unbounded<long>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = long.TryParse(s, style, provider, out long finite);
                result = new Unbounded<long>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<long> Add(this Unbounded<long> left, Unbounded<long> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<long> Substract(this Unbounded<long> left, Unbounded<long> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<long> Multiply(this Unbounded<long> left, Unbounded<long> right)
            => UnboundedHelper.Multiply(left, right, (x, y) => x * y);

        public static Unbounded<long> Divide(this Unbounded<long> left, Unbounded<long> right)
            => UnboundedHelper.Divide(left, right, (x, y) => x / y);
    }
}
