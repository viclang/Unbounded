namespace Unbounded
{
    public static partial class UnboundedExtensions
    {
        public static Unbounded<TimeOnly> Add(this Unbounded<TimeOnly> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Unbounded<TimeOnly> AddMinutes(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Unbounded<TimeOnly> AddHours(this Unbounded<TimeOnly> left, Unbounded<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeOnly> left, Unbounded<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
