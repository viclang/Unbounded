using System.Globalization;

namespace Unbounded
{
    public static class UnboundedTimeSpan
    {
        public static Unbounded<TimeSpan> Parse(string s, IFormatProvider? provider = null)
            => Unbounded<TimeSpan>.Parse(s, s => TimeSpan.Parse(s, provider));

        public static bool TryParse(string s, out Unbounded<TimeSpan>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeSpan.TryParse(s, out TimeSpan finite);
                result = new Unbounded<TimeSpan>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, IFormatProvider provider, out Unbounded<TimeSpan>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeSpan.TryParse(s, provider, out TimeSpan finite);
                result = new Unbounded<TimeSpan>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, out Unbounded<TimeSpan>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeSpan.TryParseExact(s, format, provider, out TimeSpan finite);
                result = new Unbounded<TimeSpan>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles styles, out Unbounded<TimeSpan>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeSpan.TryParseExact(s, formats, provider, out TimeSpan finite);
                result = new Unbounded<TimeSpan>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<TimeSpan> Add(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);
    }
}
