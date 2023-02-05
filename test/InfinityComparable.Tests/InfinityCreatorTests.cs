namespace InfinityComparable.Tests
{
    public class InfinityCreatorTests
    {
        private static readonly int? intNull = null;

        public static TheoryData<Infinity<int>, Infinity<int>> AllCreatorsShouldBeEqual = new()
            {
                { Inf<int>(), Infinity<int>.PositiveInfinity },
                { +Inf<int>(), Infinity<int>.PositiveInfinity },
                { Inf<int>(true), Infinity<int>.PositiveInfinity },
                { intNull.ToPositiveInfinity(), Infinity<int>.PositiveInfinity },
                { intNull.ToInfinity(true), Infinity<int>.PositiveInfinity },
                { Inf<int>(false), Infinity<int>.NegativeInfinity },
                { -Inf<int>(), Infinity<int>.NegativeInfinity },
                { intNull.ToInfinity(false), Infinity<int>.NegativeInfinity },
                { intNull.ToNegativeInfinity(), Infinity<int>.NegativeInfinity },
            };

        [Theory]
        [MemberData(nameof(AllCreatorsShouldBeEqual))]
        public void InfinityCreators_ShouldBeExpected(Infinity<int> actual, Infinity<int> expected)
        {
            actual.Should().Be(expected);
        }
    }
}
