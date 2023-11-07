namespace Unbounded.Tests;

public class EqualsTests : ComparableTestsBase
{
    [Theory]
    [MemberData(nameof(AllCompareToWithExpectedResult))]
    public void AllEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
    {
        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().Be(compareResult == 0);
    }

    [Theory]
    [MemberData(nameof(AllCompareToWithExpectedResult))]
    public void AllEqualsObject_ShouldGiveExpectedResult(Unbounded<int> a, object? b, int compareResult)
    {
        // Act
        var actual = a.Equals(b);

        // Assert
        actual.Should().Be(compareResult == 0);
    }

    [Fact]
    public void None_Equals_None_ReturnsTrue()
    {
        // Act
        var actual = new bool[]
        {
            Unbounded<int>.None.Equals(Unbounded<int>.None),
            Unbounded<int>.None.Equals((object)Unbounded<int>.None),
            Unbounded<double>.None.Equals(double.NaN),
            Unbounded<float>.None.Equals(float.NaN),
            double.NaN.Equals(double.NaN),
            float.NaN.Equals(float.NaN),
            double.NaN.Equals(float.NaN)
        };

        // Assert
        actual.Should().AllBeEquivalentTo(true);
    }
}
