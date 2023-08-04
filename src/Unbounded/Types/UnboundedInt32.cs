using System.Globalization;

namespace Unbounded
{
    public static class UnboundedInt32
    {
        public static Unbounded<int> Parse(
            string s,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider? provider = null)
            => new(int.Parse(s, style, provider));

        public static bool TryParse(string s, out Unbounded<int>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = int.TryParse(s, out int finite);
                result = new Unbounded<int>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Unbounded<int>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = int.TryParse(s, style, provider, out int finite);
                result = new Unbounded<int>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<int> Add(this Unbounded<int> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<int> Substract(this Unbounded<int> left, Unbounded<int> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<int> Divide(this Unbounded<int> left, Unbounded<int> right)
            => UnboundedHelper.Divide(left, right, (x, y) => x / y);

        public static Unbounded<int> Multiply(this Unbounded<int> left, Unbounded<int> right)
            => UnboundedHelper.Multiply(left, right, (x, y) => x * y);
    }
}
