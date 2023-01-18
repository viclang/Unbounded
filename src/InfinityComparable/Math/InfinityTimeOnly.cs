namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<TimeOnly> Add(this Infinity<TimeOnly> left, Infinity<TimeSpan> right)
            => Add(left, right, (x, y) => x.Add(y));

        public static Infinity<TimeOnly> AddMinutes(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddMinutes(y));

        public static Infinity<TimeOnly> AddHours(this Infinity<TimeOnly> left, Infinity<double> right)
            => Add(left, right, (x, y) => x.AddHours(y));

        public static Infinity<TimeSpan> Substract(this Infinity<TimeOnly> left, Infinity<TimeOnly> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
