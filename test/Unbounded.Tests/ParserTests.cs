using FluentAssertions.Execution;

namespace Unbounded.Tests
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
            var actualEmpty = Unbounded<int>.Parse(string.Empty);
            var actualPositiveInfinity = Unbounded<int>.Parse(_positiveInfinity);
            var actualNegativeInfinity = Unbounded<int>.Parse(_negativeInfinity);
            var actualFinite = Unbounded<int>.Parse(finite);

            // Assert
            using (new AssertionScope())
            {
                actualEmpty.Should().Be(Unbounded<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }

        [Fact]
        public void ParseCustom_ShouldBeExpected()
        {
            // Arrange
            var finite = "1,0";

            // Act
            var actualEmpty = Unbounded<int>.Parse(string.Empty);
            var actualPositiveInfinity = Unbounded<int>.Parse(_positiveInfinity, fin => (int)double.Parse(fin));
            var actualNegativeInfinity = Unbounded<int>.Parse(_negativeInfinity, fin => (int)double.Parse(fin));
            var actualFinite = Unbounded<int>.Parse(finite, fin => (int)double.Parse(fin));

            // Assert
            using (new AssertionScope())
            {
                actualEmpty.Should().Be(Unbounded<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
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
                Unbounded<int>.TryParse(string.Empty, out var actualEmpty),
                Unbounded<int>.TryParse(_positiveInfinity, out var actualPositiveInfinity),
                Unbounded<int>.TryParse(_negativeInfinity, out var actualNegativeInfinity),
                Unbounded<int>.TryParse(finite, out var actualFinite),
            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Unbounded<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
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
                Unbounded<int>.TryParse(string.Empty, fin => (int)double.Parse(fin), out var actualEmpty),
                Unbounded<int>.TryParse(_positiveInfinity, fin => (int)double.Parse(fin), out var actualPositiveInfinity),
                Unbounded<int>.TryParse(_negativeInfinity, fin => (int)double.Parse(fin), out var actualNegativeInfinity),
                Unbounded<int>.TryParse(finite, fin => (int)double.Parse(fin), out var actualFinite)
            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Unbounded<int>.PositiveInfinity);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }
    }
}
