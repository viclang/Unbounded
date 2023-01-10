namespace InfinityComparable.Tests
{
    public class ToStringTests
    {
        [Fact]
        public void ToStringDefault_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = Infinity<int>.PositiveInfinity;
            var negativeInfinity = Infinity<int>.NegativeInfinity;
            var finite = Inf<int>(1);

            // Act
            var actualPositiveInfinity = positiveInfinity.ToString();
            var actualNegativeInfinity = negativeInfinity.ToString();
            var actualFinite = finite.ToString();

            // Assert
            actualPositiveInfinity.Should().Be("Infinity");
            actualNegativeInfinity.Should().Be("-Infinity");
            actualFinite.Should().Be("1");
        }

        [Fact]
        public void ToStringCustom_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = Infinity<int>.PositiveInfinity;
            var negativeInfinity = Infinity<int>.NegativeInfinity;
            var finite = Inf<int>(1);

            // Act
            var actualPositiveInfinity = positiveInfinity.ToString(fin => fin.ToString(), inf => inf ? "+∞" : "-∞");
            var actualNegativeInfinity = negativeInfinity.ToString(fin => fin.ToString(), inf => inf ? "+∞" : "-∞");
            var actualFinite = finite.ToString(fin => fin.ToString("0.0"), inf => inf.ToString());

            // Assert
            actualPositiveInfinity.Should().Be("+∞");
            actualNegativeInfinity.Should().Be("-∞");
            actualFinite.Should().Be("1,0");
        }
    }
}
