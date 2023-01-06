namespace InfinityComparable.Tests
{
    public class ParserTests
    {
        [Fact]
        public void ParseDefault_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = "Infinity";
            var negativeInfinity = "-Infinity";
            var finite = "1";

            // Act
            var actualEmpty = Parse<int>(string.Empty);
            var actualPositiveInfinity = Parse<int>(positiveInfinity);
            var actualNegativeInfinity = Parse<int>(negativeInfinity);
            var actualFinite = Parse<int>(finite);

            // Assert
            actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
            actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
            actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
            actualFinite.Should().Be(1);
        }

        [Fact]
        public void ParseCustom_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = "+∞";
            var negativeInfinity = "-∞";
            var finite = "1,0";

            // Act
            var actualEmpty = Parse<int>(string.Empty);
            var actualPositiveInfinity = Parse(positiveInfinity, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞");
            var actualNegativeInfinity = Parse(negativeInfinity, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞");
            var actualFinite = Parse(finite, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞");

            // Assert
            actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
            actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
            actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
            actualFinite.Should().Be(1);
        }


        [Fact]
        public void TryParseDefault_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = "Infinity";
            var negativeInfinity = "-Infinity";
            var finite = "1";

            // Act
            var actualResult = new bool[]
            {
                TryParse<int>(string.Empty, out var actualEmpty),
                TryParse<int>(positiveInfinity, out var actualPositiveInfinity),
                TryParse<int>(negativeInfinity, out var actualNegativeInfinity),
                TryParse<int>(finite, out var actualFinite),

            };

            // Assert
            actualResult.Should().AllBeEquivalentTo(true);
            actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
            actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
            actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
            actualFinite.Should().Be(1);
        }


        [Fact]
        public void TryParseCustom_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = "+∞";
            var negativeInfinity = "-∞";
            var finite = "1,0";

            // Act
            var actualResult = new bool[]
            {
                TryParse<int>(string.Empty, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞", out var actualEmpty),
                TryParse<int>(positiveInfinity, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞", out var actualPositiveInfinity),
                TryParse<int>(negativeInfinity, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞", out var actualNegativeInfinity),
                TryParse<int>(finite, fin => (int)double.Parse(fin), pos => pos ? "+∞" : "-∞", out var actualFinite),

            };

            // Assert
            actualResult.Should().AllBeEquivalentTo(true);
            actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
            actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
            actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
            actualFinite.Should().Be(1);
        }
    }
}
