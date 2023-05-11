//using FluentAssertions.Execution;

//namespace InfinityComparable.Tests
//{
//    public class OperatorTests : ComparableTestsBase
//    {
//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void AllEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a == b;

//            // Assert
//            actual.Should().Be(compareResult == 0);
//        }

//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void AllNotEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a != b;

//            // Assert
//            actual.Should().Be(compareResult != 0);
//        }

//        [Fact]
//        public void NaN_Equals_NaN_ReturnsTrue()
//        {
//            // Act
//            var actual = Unbounded<int>.NaN == Unbounded<int>.NaN;

//            // Assert
//            actual.Should().BeFalse();
//        }

//        [Fact]
//        public void NaN_NotEquals_NaN_ReturnsTrue()
//        {
//            // Act
//            var actual = Unbounded<int>.NaN != Unbounded<int>.NaN;

//            // Assert
//            actual.Should().BeTrue();
//        }

//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void GreaterThan_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a > b;

//            // Assert
//            actual.Should().Be(compareResult == 1);
//        }

//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void SmallerThan_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a < b;

//            // Assert
//            actual.Should().Be(compareResult == -1);
//        }

//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void GreaterThanOrEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a >= b;

//            // Assert
//            actual.Should().Be(compareResult >= 0);
//        }

//        [Theory]
//        [MemberData(nameof(AllCompareToWithExpectedResult))]
//        public void SmallerThanOrEquals_ShouldGiveExpectedResult(Unbounded<int> a, Unbounded<int> b, int compareResult)
//        {
//            // Act
//            var actual = a <= b;

//            // Assert
//            actual.Should().Be(compareResult <= 0);
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData(1)]
//        public void GivenNullable_ImplicitOperator_ReturnsNegativeInfinity(int? nullable)
//        {
//            // Act
//            Unbounded<int> actual = nullable;

//            // Assert
//            actual.Should().Be(nullable.ToNegativeInfinity());
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData(1)]
//        public void GivenInfinity_ExplicitOperator_ReturnsNull(int? expected)
//        {
//            // Arrange
//            Unbounded<int> infinity = expected;

//            // Act
//            int? actual = (int?)infinity;

//            // Assert
//            actual.Should().Be(expected);
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData(1)]
//        public void GivenPositiveInfinity_UnaryNegationOperator_ReturnsNegativeInfinity(int? nullable)
//        {
//            // Act
//            var actual = -nullable.ToPositiveInfinity();

//            // Assert
//            actual.Should().Be(nullable.ToNegativeInfinity());
//        }

//        [Theory]
//        [InlineData(null)]
//        [InlineData(1)]
//        public void GivenNegativeInfinity_UnaryPlusOperator_PositiveInfinity(int? nullable)
//        {
//            // Act
//            var actual = +nullable.ToNegativeInfinity();

//            // Assert
//            actual.Should().Be(nullable.ToPositiveInfinity());
//        }


//        [Theory]
//        [InlineData(null)]
//        [InlineData(1)]
//        public void GivenInfinity_LogicalNotOperator_ReturnsOppositeInfinity(int? nullable)
//        {
//            // Act
//            var actual = new Unbounded<int>[]
//            {
//                !nullable.ToNegativeInfinity(),
//                !nullable.ToPositiveInfinity(),
//            };

//            // Assert
//            using(new AssertionScope())
//            {
//                actual[0].Should().Be(nullable.ToPositiveInfinity());
//                actual[1].Should().Be(nullable.ToNegativeInfinity());
//            }
//        }
//    }
//}
