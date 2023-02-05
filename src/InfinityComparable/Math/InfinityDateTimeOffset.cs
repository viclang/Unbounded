namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<DateTimeOffset> Add(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<DateTimeOffset> AddMilliseconds(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMilliseconds(y));

        public static Infinity<DateTimeOffset> AddSeconds(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddSeconds(y));

        public static Infinity<DateTimeOffset> AddMinutes(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<DateTimeOffset> AddHours(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<DateTimeOffset> AddDays(this Infinity<DateTimeOffset> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddDays(y));

        public static Infinity<DateTimeOffset> AddMonths(this Infinity<DateTimeOffset> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddMonths(y));

        public static Infinity<DateTimeOffset> AddYears(this Infinity<DateTimeOffset> left, Infinity<int> right)
            => Add(left, right, (x, y) => x.AddYears(y));

        public static Infinity<DateTimeOffset> AddTicks(this Infinity<DateTimeOffset> left, Infinity<long> right)
            => Add(left, right, (x, y) => x.AddTicks(y));

        public static Infinity<DateTimeOffset> Substract(this Infinity<DateTimeOffset> left, Infinity<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<TimeSpan> Substract(this Infinity<DateTimeOffset> left, Infinity<DateTimeOffset> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
