using System.Globalization;

namespace Unbounded
{
    public static class UnboundedTimeOnly
    {
        public static Unbounded<TimeOnly> Parse(string s, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None)
            => Unbounded<TimeOnly>.Parse(s, s => TimeOnly.Parse(s, provider, styles));

        public static bool TryParse(string s, out Unbounded<TimeOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeOnly.TryParse(s, out TimeOnly finite);
                result = new Unbounded<TimeOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out Unbounded<TimeOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeOnly.TryParse(s, provider, styles, out TimeOnly finite);
                result = new Unbounded<TimeOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles styles, out Unbounded<TimeOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeOnly.TryParseExact(s, format, provider, styles, out TimeOnly finite);
                result = new Unbounded<TimeOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles styles, out Unbounded<TimeOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = TimeOnly.TryParseExact(s, formats, provider, styles, out TimeOnly finite);
                result = new Unbounded<TimeOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<TimeOnly> Add(this Unbounded<TimeOnly> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.Add(y));

        public static Unbounded<TimeOnly> AddMinutes(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<TimeOnly> AddHours(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeOnly> left, Unbounded<TimeOnly> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);
    }
}
