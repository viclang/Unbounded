namespace InfinityComparable.Tests
{
    public class ComparableTests : ComparableTestsBase
    {
        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void AllCompareTo_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int expected)
        {
            // Act
            var actual = a.CompareTo(b);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        [MemberData(nameof(AllCompareToObjectWithExpectedResult))]
        public void AllCompareToObject_ShouldGiveExpectedResult(Infinity<int> a, object? b, int expected)
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
                Infinity<int>.NaN.CompareTo(Infinity<int>.NaN),
                Infinity<int>.NaN.CompareTo((object)Infinity<int>.NaN),
                Infinity<int>.NaN.CompareTo(double.NaN),
                Infinity<int>.NaN.CompareTo(float.NaN),
                double.NaN.CompareTo(double.NaN),
                float.NaN.CompareTo(float.NaN),
                double.NaN.CompareTo(float.NaN)
            };

            // Assert
            actual.Should().AllBeEquivalentTo(0);
        }
    }
}