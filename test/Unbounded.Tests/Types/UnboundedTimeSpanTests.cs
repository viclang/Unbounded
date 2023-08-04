using Unbounded.Tests.Factories;

namespace Unbounded.Tests
{
    public class UnboundedTimeSpanTests
    {
        private static readonly TimeSpan _left = TimeSpan.FromDays(2);
        private static readonly TimeSpan _right = TimeSpan.FromDays(1);

        public static TheoryData<Unbounded<TimeSpan>, Unbounded<TimeSpan>, Unbounded<TimeSpan>> AddData =
            UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Int32_Add_ReturnsExpected(Unbounded<TimeSpan> left, Unbounded<TimeSpan> right, Unbounded<TimeSpan> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<TimeSpan>, Unbounded<TimeSpan>, Unbounded<TimeSpan>> SubstractData =
            UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Int32_Substract_ReturnsExpected(Unbounded<TimeSpan> left, Unbounded<TimeSpan> right, Unbounded<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
