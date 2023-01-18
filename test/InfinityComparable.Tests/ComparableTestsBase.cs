namespace InfinityComparable.Tests
{
    public abstract class ComparableTestsBase
    {
        private static readonly Infinity<int> maxFinite = new Infinity<int>(int.MaxValue);
        private static readonly Infinity<int> minFinite = new Infinity<int>(int.MinValue);

        // Arrange
        public static TheoryData<Infinity<int>, Infinity<int>, int> AllCompareToWithExpectedResult =
            new()
            {
                { Infinity<int>.PositiveInfinity, Infinity<int>.PositiveInfinity, 0 },
                { Infinity<int>.NegativeInfinity, Infinity<int>.NegativeInfinity, 0 },
                { Infinity<int>.PositiveInfinity, Infinity<int>.NegativeInfinity, 1 },
                { Infinity<int>.NegativeInfinity, Infinity<int>.PositiveInfinity, -1 },
                { Infinity<int>.PositiveInfinity, maxFinite, 1 },
                { Infinity<int>.NegativeInfinity, minFinite, -1 },
                { minFinite, Infinity<int>.NegativeInfinity, 1 },
                { maxFinite, Infinity<int>.PositiveInfinity, -1 },
                { minFinite, Infinity<int>.NaN, 1 },
                { Infinity<int>.NaN, minFinite, -1 },
                { minFinite, minFinite, 0 },
                { maxFinite, minFinite, 1 },
                { minFinite, maxFinite, -1 },
            };

        public static TheoryData<Infinity<int>, object?, int> AllCompareToObjectWithExpectedResult =
            new()
            {
                { Infinity<int>.PositiveInfinity, float.PositiveInfinity, 0 },
                { Infinity<int>.PositiveInfinity, double.PositiveInfinity, 0 },
                { Infinity<int>.NegativeInfinity, float.NegativeInfinity, 0 },
                { Infinity<int>.NegativeInfinity, double.NegativeInfinity, 0 },
                { Infinity<int>.PositiveInfinity, float.NegativeInfinity, 1 },
                { Infinity<int>.PositiveInfinity, double.NegativeInfinity, 1 },
                { Infinity<int>.NegativeInfinity, float.PositiveInfinity, -1 },
                { Infinity<int>.NegativeInfinity, double.PositiveInfinity, -1 },
                { minFinite, float.NaN, 1 },
                { minFinite, double.NaN, 1 },
            };
    }
}