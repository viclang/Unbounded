using System.Globalization;

namespace Unbounded
{
    public static class UnboundedDateTimeOffset
    {
        public static Unbounded<DateTimeOffset> Parse(string s, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None)
            => Unbounded<DateTimeOffset>.Parse(s, s => DateTimeOffset.Parse(s, provider, styles));

        public static bool TryParse(string s, out Unbounded<DateTimeOffset>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTimeOffset.TryParse(s, out DateTimeOffset finite);
                result = new Unbounded<DateTimeOffset>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTimeOffset>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTimeOffset.TryParse(s, provider, styles, out DateTimeOffset finite);
                result = new Unbounded<DateTimeOffset>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string? format, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTimeOffset>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTimeOffset.TryParseExact(s, format, provider, styles, out DateTimeOffset finite);
                result = new Unbounded<DateTimeOffset>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string[]? formats, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTimeOffset>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTimeOffset.TryParseExact(s, formats, provider, styles, out DateTimeOffset finite);
                result = new Unbounded<DateTimeOffset>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<DateTimeOffset> Add(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<DateTimeOffset> AddMilliseconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Unbounded<DateTimeOffset> AddSeconds(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddSeconds(y));

        public static Unbounded<DateTimeOffset> AddMinutes(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<DateTimeOffset> AddHours(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<DateTimeOffset> AddDays(this Unbounded<DateTimeOffset> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateTimeOffset> AddMonths(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateTimeOffset> AddYears(this Unbounded<DateTimeOffset> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<DateTimeOffset> AddTicks(this Unbounded<DateTimeOffset> left, Unbounded<long> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddTicks(y));

        public static Unbounded<DateTimeOffset> Substract(this Unbounded<DateTimeOffset> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<DateTimeOffset> left, Unbounded<DateTimeOffset> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);
    }
}
