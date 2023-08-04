using System.Globalization;

namespace Unbounded
{
    public static class UnboundedDateTime
    {
        public static Unbounded<DateTime> Parse(string s, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None)
            => Unbounded<DateTime>.Parse(s, s => DateTime.Parse(s, provider, styles));

        public static bool TryParse(string s, out Unbounded<DateTime>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTime.TryParse(s, out DateTime finite);
                result = new Unbounded<DateTime>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParse(string s, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTime>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTime.TryParse(s, provider, styles, out DateTime finite);
                result = new Unbounded<DateTime>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string? format, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTime>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTime.TryParseExact(s, format, provider, styles, out DateTime finite);
                result = new Unbounded<DateTime>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static bool TryParseExact(string s, string[]? formats, IFormatProvider? provider, DateTimeStyles styles, out Unbounded<DateTime>? result)
        {
            if (!UnboundedHelper.TryParseUnbounded(s, out result))
            {
                var isSuccesful = DateTime.TryParseExact(s, formats, provider, styles, out DateTime finite);
                result = new Unbounded<DateTime>(finite);
                return isSuccesful;
            }
            return true;
        }

        public static Unbounded<DateTime> Add(this Unbounded<DateTime> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<DateTime> AddMilliseconds(this Unbounded<DateTime> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Unbounded<DateTime> AddSeconds(this Unbounded<DateTime> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddSeconds(y));

        public static Unbounded<DateTime> AddMinutes(this Unbounded<DateTime> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<DateTime> AddHours(this Unbounded<DateTime> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<DateTime> AddDays(this Unbounded<DateTime> left, Unbounded<double> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateTime> AddMonths(this Unbounded<DateTime> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateTime> AddYears(this Unbounded<DateTime> left, Unbounded<int> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<DateTime> AddTicks(this Unbounded<DateTime> left, Unbounded<long> right)
            => UnboundedHelper.Add(left, right, (x, y) => x.AddTicks(y));

        public static Unbounded<DateTime> Substract(this Unbounded<DateTime> left, Unbounded<TimeSpan> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<DateTime> left, Unbounded<DateTime> right)
            => UnboundedHelper.Substract(left, right, (x, y) => x - y);
    }
}
