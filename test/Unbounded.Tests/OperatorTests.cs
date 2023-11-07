using FluentAssertions.Execution;
using Unbounded;
using Unbounded.Tests;

namespace InfinityComparable.Tests
{
    public class OperatorTests : ComparableTestsBase
    {
        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void AllEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a == b;

            // Assert
            actual.Should().Be(compareResult == 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void AllNotEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a != b;

            // Assert
            actual.Should().Be(compareResult != 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void GreaterThan_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a > b;

            // Assert
            actual.Should().Be(compareResult == 1);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void SmallerThan_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a < b;

            // Assert
            actual.Should().Be(compareResult == -1);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void GreaterThanOrEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a >= b;

            // Assert
            actual.Should().Be(compareResult >= 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void SmallerThanOrEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
        {
            // Act
            var actual = a <= b;

            // Assert
            actual.Should().Be(compareResult <= 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public void GivenInfinity_ExplicitOperator_ReturnsNull(int? expected)
        {
            // Arrange
            Unbounded<int> infinity = expected;

            // Act
            int? actual = (int?)infinity;

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public void GivenPositiveInfinity_UnaryNegationOperator_ReturnsNegativeInfinity(int? nullable)
        {
            // Act
            var actual = -nullable.ToPositiveInfinity();

            // Assert
            actual.Should().Be(nullable.ToNegativeInfinity());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public void GivenNegativeInfinity_UnaryPlusOperator_PositiveInfinity(int? nullable)
        {
            // Act
            var actual = +nullable.ToNegativeInfinity();

            // Assert
            actual.Should().Be(nullable.ToPositiveInfinity());
        }
    }
}
