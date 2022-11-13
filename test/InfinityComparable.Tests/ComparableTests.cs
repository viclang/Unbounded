namespace InifinityComparable.Tests
{
    public class ComparableTests
    {
        private static readonly Infinity<int> maxFinite = new Infinity<int>(int.MaxValue, true);
        private static readonly Infinity<int> minFinite = new Infinity<int>(int.MinValue, true);
        private static readonly Infinity<int> negativeMinFinite = new Infinity<int>(int.MinValue, false);
        private static readonly Infinity<int> negativeMaxFinite = new Infinity<int>(int.MaxValue, false);


        // Arrange
        public static TheoryData<Infinity<int>, Infinity<int>, int> AllCompareToWithExpectedResult =
            new TheoryData<Infinity<int>, Infinity<int>, int>
            {
                { Infinity<int>.PositiveInfinity, Infinity<int>.PositiveInfinity, 0 },
                { Infinity<int>.NegativeInfinity, Infinity<int>.NegativeInfinity, 0 },
                { Infinity<int>.PositiveInfinity, Infinity<int>.NegativeInfinity, 1 },
                { Infinity<int>.NegativeInfinity, Infinity<int>.PositiveInfinity, -1 },
                { minFinite, negativeMinFinite, 0 },
                { maxFinite, negativeMaxFinite, 0 },
                { Infinity<int>.PositiveInfinity, maxFinite, 1 },
                { Infinity<int>.NegativeInfinity, minFinite, -1 },
                { minFinite, Infinity<int>.NegativeInfinity, 1 },
                { maxFinite, Infinity<int>.PositiveInfinity, -1 },
            };

        public static TheoryData<Infinity<int>, object?, int> AllCompareToObjectWithExpectedResult =
            new TheoryData<Infinity<int>, object?, int>
            {
                { Infinity<int>.PositiveInfinity, float.PositiveInfinity, 0 },
                { Infinity<int>.PositiveInfinity, double.PositiveInfinity, 0 },
                { Infinity<int>.NegativeInfinity, float.NegativeInfinity, 0 },
                { Infinity<int>.NegativeInfinity, double.NegativeInfinity, 0 },
                { Infinity<int>.PositiveInfinity, float.NegativeInfinity, 1 },
                { Infinity<int>.PositiveInfinity, double.NegativeInfinity, 1 },
                { Infinity<int>.NegativeInfinity, float.PositiveInfinity, -1 },
                { Infinity<int>.NegativeInfinity, double.PositiveInfinity, -1 }
            };

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

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void AllEquals_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int compareResult)
        {
            // Act
            var actual = a.Equals(b);

            // Assert
            actual.Should().Be(compareResult == 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        [MemberData(nameof(AllCompareToObjectWithExpectedResult))]
        public void AllEqualsObject_ShouldGiveExpectedResult(Infinity<int> a, object? b, int compareResult)
        {
            // Act
            var actual = a.Equals(b);

            // Assert
            actual.Should().Be(compareResult == 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void GreaterThan_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int compareResult)
        {
            // Act
            var actual = a > b;

            // Assert
            actual.Should().Be(compareResult == 1);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void SmallerThan_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int compareResult)
        {
            // Act
            var actual = a < b;

            // Assert
            actual.Should().Be(compareResult == -1);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void GreaterThanOrEquals_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int compareResult)
        {
            // Act
            var actual = a >= b;

            // Assert
            actual.Should().Be(compareResult >= 0);
        }

        [Theory]
        [MemberData(nameof(AllCompareToWithExpectedResult))]
        public void SmallerThanOrEquals_ShouldGiveExpectedResult(Infinity<int> a, Infinity<int> b, int compareResult)
        {
            // Act
            var actual = a <= b;

            // Assert
            actual.Should().Be(compareResult <= 0);
        }
    }
}