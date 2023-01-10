using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityTimeSpanTests
    {
        private static readonly TimeSpan _left = TimeSpan.FromDays(2);
        private static readonly TimeSpan _right = TimeSpan.FromDays(1);

        public static TheoryData<Infinity<TimeSpan>, Infinity<TimeSpan>, Infinity<TimeSpan>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Int32_Add_ReturnsExpected(Infinity<TimeSpan> left, Infinity<TimeSpan> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<TimeSpan>, Infinity<TimeSpan>, Infinity<TimeSpan>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Int32_Substract_ReturnsExpected(Infinity<TimeSpan> left, Infinity<TimeSpan> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
