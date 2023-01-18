using FluentAssertions.Execution;

namespace InfinityComparable.Tests
{
    public class ParserTests
    {
        private const string _negativeInfinity = "-Infinity";
        private const string _positiveInfinity = "Infinity";

        [Fact]
        public void ParseDefault_ShouldBeExpected()
        {
            // Arrange
            var finite = "1";

            // Act
            var actualEmpty = Parse<int>(string.Empty);
            var actualPositiveInfinity = Parse<int>(_positiveInfinity);
            var actualNegativeInfinity = Parse<int>(_negativeInfinity);
            var actualFinite = Parse<int>(finite);

            // Assert
            using (new AssertionScope())
            {
                actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }

        [Fact]
        public void ParseCustom_ShouldBeExpected()
        {
            // Arrange
            var finite = "1,0";

            // Act
            var actualEmpty = Parse<int>(string.Empty);
            var actualPositiveInfinity = Parse(_positiveInfinity, fin => (int)double.Parse(fin));
            var actualNegativeInfinity = Parse(_negativeInfinity, fin => (int)double.Parse(fin));
            var actualFinite = Parse(finite, fin => (int)double.Parse(fin));

            // Assert
            using (new AssertionScope())
            {
                actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }


        [Fact]
        public void TryParseDefault_ShouldBeExpected()
        {
            // Arrange
            var finite = "1";

            // Act
            var actualResult = new bool[]
            {
                TryParse<int>(string.Empty, out var actualEmpty),
                TryParse<int>(_positiveInfinity, out var actualPositiveInfinity),
                TryParse<int>(_negativeInfinity, out var actualNegativeInfinity),
                TryParse<int>(finite, out var actualFinite),

            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }


        [Fact]
        public void TryParseCustom_ShouldBeExpected()
        {
            // Arrange
            var finite = "1,0";

            // Act
            var actualResult = new bool[]
            {
                TryParse(string.Empty, fin => (int)double.Parse(fin), out var actualEmpty),
                TryParse(_positiveInfinity, fin => (int)double.Parse(fin), out var actualPositiveInfinity),
                TryParse(_negativeInfinity, fin => (int)double.Parse(fin), out var actualNegativeInfinity),
                TryParse(finite, fin => (int)double.Parse(fin), out var actualFinite)
            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Infinity<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Infinity<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Infinity<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }
    }
}
