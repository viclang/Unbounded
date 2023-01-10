namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<float> Add(this Infinity<float> left, Infinity<float> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<float> Substract(this Infinity<float> left, Infinity<float> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<float> Multiply(this Infinity<float> left, Infinity<float> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Infinity<float> Divide(this Infinity<float> left, Infinity<float> right)
            => Divide(left, right, (x, y) => x / y);
    }
}
