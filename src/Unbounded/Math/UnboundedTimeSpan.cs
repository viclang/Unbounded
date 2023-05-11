namespace Unbounded
{
    public static partial class UnboundedExtensions
    {
        public static Unbounded<TimeSpan> Add(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
