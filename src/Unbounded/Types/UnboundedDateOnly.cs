using System.Globalization;

namespace Unbounded
{
    public static partial class UnboundedDateOnly
    {
        public static Unbounded<DateOnly> Parse(string s, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None)
            => Unbounded<DateOnly>.Parse(s, s => DateOnly.Parse(s, provider, styles));

        public static bool TryParse(string s, out Unbounded<DateOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateOnly.TryParse(s, out DateOnly finite);
                result = new Unbounded<DateOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out Unbounded<DateOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateOnly.TryParse(s, provider, styles, out DateOnly finite);
                result = new Unbounded<DateOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles styles, out Unbounded<DateOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateOnly.TryParseExact(s, format, provider, styles, out DateOnly finite);
                result = new Unbounded<DateOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles styles, out Unbounded<DateOnly>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateOnly.TryParseExact(s, formats, provider, styles, out DateOnly finite);
                result = new Unbounded<DateOnly>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<DateOnly> AddDays(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateOnly> AddMonths(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateOnly> AddYears(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<int> Substract(this Unbounded<DateOnly> left, Unbounded<DateOnly> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x.DayNumber - y.DayNumber);
    }
}
