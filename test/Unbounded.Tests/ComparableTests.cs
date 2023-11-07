namespace Unbounded.Tests;

public class ComparableTests : ComparableTestsBase
{
    [Theory]
    [MemberData(nameof(AllCompareToWithExpectedResult))]
    public void AllCompareTo_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int expected)
    {
        // Act
        var actual = a.CompareTo(b);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(AllCompareToWithExpectedResult))]
    public void AllCompareToObject_ShouldGiveExpectedResult(Unbounded<int> a, object? b, int expected)
    {
        // Act
        var actual = a.CompareTo(b);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void None_CompareTo_None_ReturnsZero()
    {
        // Act
        var actual = new int[]
        {
            Unbounded<int>.None.CompareTo(Unbounded<int>.None),
            Unbounded<int>.None.CompareTo((object)Unbounded<int>.None),
            Unbounded<double>.None.CompareTo(double.NaN),
            Unbounded<float>.None.CompareTo(float.NaN),
            double.NaN.CompareTo(double.NaN),
            float.NaN.CompareTo(float.NaN),
            double.NaN.CompareTo(float.NaN)
        };

        // Assert
        actual.Should().AllBeEquivalentTo(0);
    }
}