namespace Unbounded.Tests;

public abstract class ComparableTestsBase
{
    private static readonly Unbounded<int> maxFinite = new(int.MaxValue);
    private static readonly Unbounded<int> minFinite = new(int.MinValue);

    // Arrange
    public static TheoryData<Unbounded<int>, Unbounded<int>, int> AllCompareToWithExpectedResult =
        new()
        {
            { Unbounded<int>.None, Unbounded<int>.NegativeInfinity, -1 },
            { Unbounded<int>.None, Unbounded<int>.PositiveInfinity, -1 },
            { Unbounded<int>.NegativeInfinity, Unbounded<int>.None, 1 },
            { Unbounded<int>.PositiveInfinity, Unbounded<int>.None, 1 },
            { Unbounded<int>.PositiveInfinity, Unbounded<int>.PositiveInfinity, 0 },
            { Unbounded<int>.NegativeInfinity, Unbounded<int>.NegativeInfinity, 0 },
            { Unbounded<int>.PositiveInfinity, Unbounded<int>.NegativeInfinity, 1 },
            { Unbounded<int>.NegativeInfinity, Unbounded<int>.PositiveInfinity, -1 },
            { Unbounded<int>.PositiveInfinity, maxFinite, 1 },
            { Unbounded<int>.NegativeInfinity, minFinite, -1 },
            { minFinite, Unbounded<int>.NegativeInfinity, 1 },
            { maxFinite, Unbounded<int>.PositiveInfinity, -1 },
            { minFinite, Unbounded<int>.None, 1 },
            { Unbounded<int>.None, minFinite, -1 },
            { minFinite, minFinite, 0 },
            { maxFinite, minFinite, 1 },
            { minFinite, maxFinite, -1 },
        };
}