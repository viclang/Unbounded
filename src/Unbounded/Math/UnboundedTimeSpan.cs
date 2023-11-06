namespace Unbounded
{
    public static class UnboundedTimeSpan
    {
        public static Unbounded<TimeSpan> Add(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => UnboundedMathHelper.Add(left, right, (x, y) => x + y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => UnboundedMathHelper.Substract(left, right, (x, y) => x - y);
    }
}
