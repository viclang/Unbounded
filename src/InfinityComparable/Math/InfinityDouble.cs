namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<double> Add(this Infinity<double> left, Infinity<double> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<double> Substract(this Infinity<double> left, Infinity<double> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<double> Divide(this Infinity<double> left, Infinity<double> right)
            => Divide(left, right, (x, y) => x / y);

        public static Infinity<double> Multiply(this Infinity<double> left, Infinity<double> right)
            => Multiply(left, right, (x, y) => x * y);

        public static double ToDouble(this Infinity<double> value) => value.State switch
        {
            InfinityState.IsFinite => value.value,
            InfinityState.IsInfinity => value.positive ? double.PositiveInfinity : double.NegativeInfinity,
            _ => double.NaN
        };
    }
}
