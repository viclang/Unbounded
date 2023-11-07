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
                actualEmpty.Should().Be(Unbounded<int>.None);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
                actualFinite.Should().Be(new(1));
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
                Unbounded<int>.TryParse(string.Empty, null, out var actualEmpty),
                Unbounded<int>.TryParse(_positiveInfinity, null, out var actualPositiveInfinity),
                Unbounded<int>.TryParse(_negativeInfinity, null, out var actualNegativeInfinity),
                Unbounded<int>.TryParse(finite, null, out var actualFinite),
            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Unbounded<int>.None);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }


        [Fact]
        public void TryParseCustom_ShouldBeExpected()
        {
            // Arrange
            var finite = "1";

            // Act
            var actualResult = new bool[]
            {
                Unbounded<int>.TryParse(string.Empty, null, out var actualEmpty),
                Unbounded<int>.TryParse(_positiveInfinity, null, out var actualPositiveInfinity),
                Unbounded<int>.TryParse(_negativeInfinity, null, out var actualNegativeInfinity),
                Unbounded<int>.TryParse(finite, null, out var actualFinite)
            };

            // Assert
            using (new AssertionScope())
            {
                actualResult.Should().AllBeEquivalentTo(true);
                actualEmpty.Should().Be(Unbounded<int>.None);
                actualPositiveInfinity.Should().Be(Unbounded<int>.PositiveInfinity);
                actualNegativeInfinity.Should().Be(Unbounded<int>.NegativeInfinity);
                actualFinite.Should().Be(1);
            }
        }
    }
}
