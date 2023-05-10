namespace UnboundedType.Tests
{
    public class InfinityCreatorTests
    {
        private static readonly int? intNull = null;

        //public static TheoryData<Unbounded<int>, Unbounded<int>> AllCreatorsShouldBeEqual = new()
        //    {
        //        { Inf<int>(), Unbounded<int>.PositiveInfinity },
        //        { +Inf<int>(), Unbounded<int>.PositiveInfinity },
        //        { Inf<int>(true), Unbounded<int>.PositiveInfinity },
        //        { intNull.ToPositiveInfinity(), Unbounded<int>.PositiveInfinity },
        //        { intNull.ToInfinity(true), Unbounded<int>.PositiveInfinity },
        //        { Inf<int>(false), Unbounded<int>.NegativeInfinity },
        //        { -Inf<int>(), Unbounded<int>.NegativeInfinity },
        //        { intNull.ToInfinity(false), Unbounded<int>.NegativeInfinity },
        //        { intNull.ToNegativeInfinity(), Unbounded<int>.NegativeInfinity },
        //    };

        //[Theory]
        //[MemberData(nameof(AllCreatorsShouldBeEqual))]
        //public void InfinityCreators_ShouldBeExpected(Unbounded<int> actual, Unbounded<int> expected)
        //{
        //    actual.Should().Be(expected);
        //}
    }
}
