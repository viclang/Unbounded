namespace UnboundedType.Tests
{
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
        //[MemberData(nameof(AllCompareToObjectWithExpectedResult))]
        public void AllEqualsObject_ShouldGiveExpectedResult(Unbounded<int> a, object? b, int compareResult)
        {
            // Act
            var actual = a.Equals(b);

            // Assert
            actual.Should().Be(compareResult == 0);
        }

        [Fact]
        public void NaN_Equals_NaN_ReturnsTrue()
        {
            // Act
            var actual = new bool[]
            {
                Unbounded<int>.NaN.Equals(Unbounded<int>.NaN),
                Unbounded<int>.NaN.Equals((object)Unbounded<int>.NaN),
                Unbounded<int>.NaN.Equals(double.NaN),
                Unbounded<int>.NaN.Equals(float.NaN),
                double.NaN.Equals(double.NaN),
                float.NaN.Equals(float.NaN),
                double.NaN.Equals(float.NaN)
            };

            // Assert
            actual.Should().AllBeEquivalentTo(true);
        }
    }
}
