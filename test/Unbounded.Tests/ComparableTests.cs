namespace Unbounded.Tests
{
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
        public void NaN_CompareTo_NaN_ReturnsZero()
        {
            // Act
            var actual = new int[]
            {
                Unbounded<int>.NaN.CompareTo(Unbounded<int>.NaN),
                Unbounded<int>.NaN.CompareTo((object)Unbounded<int>.NaN),
                Unbounded<double>.NaN.CompareTo(double.NaN.ToUnbounded()),
                Unbounded<float>.NaN.CompareTo(float.NaN.ToUnbounded()),
                double.NaN.CompareTo(double.NaN),
                float.NaN.CompareTo(float.NaN),
                double.NaN.CompareTo(float.NaN)
            };

            // Assert
            actual.Should().AllBeEquivalentTo(0);
        }
    }
}