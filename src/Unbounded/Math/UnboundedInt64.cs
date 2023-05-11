namespace Unbounded
{
    public static partial class UnboundedExtensions
    {
        public static Unbounded<long> Add(this Unbounded<long> left, Unbounded<long> right)
            => Add(left, right, (x, y) => x + y);

        public static Unbounded<long> Substract(this Unbounded<long> left, Unbounded<long> right)
            => Substract(left, right, (x, y) => x - y);

        public static Unbounded<long> Multiply(this Unbounded<long> left, Unbounded<long> right)
            => Multiply(left, right, (x, y) => x * y);

        public static Unbounded<long> Divide(this Unbounded<long> left, Unbounded<long> right)
            => Divide(left, right, (x, y) => x / y);
    }
}
