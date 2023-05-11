namespace UnboundedType.Tests
{
    public abstract class ComparableTestsBase
    {
        private static readonly Unbounded<int> maxFinite = int.MaxValue;
        private static readonly Unbounded<int> minFinite = new(int.MinValue);

        // Arrange
        public static TheoryData<Unbounded<int>, Unbounded<int>, int> AllCompareToWithExpectedResult =
            new()
            {
                { Unbounded<int>.NaN, Unbounded<int>.NegativeInfinity, -1 },
                { Unbounded<int>.NaN, Unbounded<int>.PositiveInfinity, -1 },
                { Unbounded<int>.NegativeInfinity, Unbounded<int>.NaN, 1 },
                { Unbounded<int>.PositiveInfinity, Unbounded<int>.NaN, 1 },
                { Unbounded<int>.PositiveInfinity, Unbounded<int>.PositiveInfinity, 0 },
                { Unbounded<int>.NegativeInfinity, Unbounded<int>.NegativeInfinity, 0 },
                { Unbounded<int>.PositiveInfinity, Unbounded<int>.NegativeInfinity, 1 },
                { Unbounded<int>.NegativeInfinity, Unbounded<int>.PositiveInfinity, -1 },
                { Unbounded<int>.PositiveInfinity, maxFinite, 1 },
                { Unbounded<int>.NegativeInfinity, minFinite, -1 },
                { minFinite, Unbounded<int>.NegativeInfinity, 1 },
                { maxFinite, Unbounded<int>.PositiveInfinity, -1 },
                { minFinite, Unbounded<int>.NaN, 1 },
                { Unbounded<int>.NaN, minFinite, -1 },
                { minFinite, minFinite, 0 },
                { maxFinite, minFinite, 1 },
                { minFinite, maxFinite, -1 },
            };

        public static TheoryData<Unbounded<int>, object?, int> AllCompareToObjectWithExpectedResult =
            new()
            {
                { Unbounded<int>.PositiveInfinity, float.PositiveInfinity, 0 },
                { Unbounded<int>.PositiveInfinity, double.PositiveInfinity, 0 },
                { Unbounded<int>.NegativeInfinity, float.NegativeInfinity, 0 },
                { Unbounded<int>.NegativeInfinity, double.NegativeInfinity, 0 },
                { Unbounded<int>.PositiveInfinity, float.NegativeInfinity, 1 },
                { Unbounded<int>.PositiveInfinity, double.NegativeInfinity, 1 },
                { Unbounded<int>.NegativeInfinity, float.PositiveInfinity, -1 },
                { Unbounded<int>.NegativeInfinity, double.PositiveInfinity, -1 },
                { minFinite, float.NaN, 1 },
                { minFinite, double.NaN, 1 },
            };
    }
}