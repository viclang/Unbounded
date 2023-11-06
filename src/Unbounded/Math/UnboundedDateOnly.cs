namespace Unbounded
{
    public static partial class UnboundedDateOnly
    {
        public static Unbounded<DateOnly> AddDays(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedMathHelper.Add(left, right, (x, y) => x.AddDays(y));

        public static Unbounded<DateOnly> AddMonths(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedMathHelper.Add(left, right, (x, y) => x.AddMonths(y));

        public static Unbounded<DateOnly> AddYears(this Unbounded<DateOnly> left, Unbounded<int> right)
            => UnboundedMathHelper.Add(left, right, (x, y) => x.AddYears(y));

        public static Unbounded<int> SubstractByDayNumber(this Unbounded<DateOnly> left, Unbounded<DateOnly> right)
            => UnboundedMathHelper.Substract(left, right, (x, y) => x.DayNumber - y.DayNumber);
    }
}
