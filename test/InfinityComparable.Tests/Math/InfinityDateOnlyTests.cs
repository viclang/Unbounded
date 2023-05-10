using UnboundedType.Tests.Factories;

namespace UnboundedType.Tests
{
    public class InfinityDateOnlyTests
    {
        private static readonly DateOnly _left = new DateOnly(2023, 1, 2);
        private static readonly DateOnly _right = new DateOnly(2023, 1, 1);
        private static readonly int _rightInt = 1;

        public static TheoryData<Unbounded<DateOnly>, Unbounded<int>, Unbounded<DateOnly>> AddDaysData =
            InfinityMathDataFactory.CreateAddData(_left, _rightInt, _left.AddDays(_rightInt));

        [Theory]
        [MemberData(nameof(AddDaysData))]
        public void DateOnly_AddDays_ReturnsExpected(
            Unbounded<DateOnly> left,
            Unbounded<int> right,
            Unbounded<DateOnly> expected)
        {
            var actual = left.AddDays(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<DateOnly>, Unbounded<int>, Unbounded<DateOnly>> AddMonthsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightInt, _left.AddMonths(_rightInt));

        [Theory]
        [MemberData(nameof(AddMonthsData))]
        public void DateOnly_AddMonth_ReturnsExpected(Unbounded<DateOnly> left, Unbounded<int> right, Unbounded<DateOnly> expected)
        {
            var actual = left.AddMonths(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<DateOnly>, Unbounded<int>, Unbounded<DateOnly>> AddYearsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightInt, _left.AddYears(_rightInt));

        [Theory]
        [MemberData(nameof(AddYearsData))]
        public void DateOnly_AddYears_ReturnsExpected(Unbounded<DateOnly> left, Unbounded<int> right, Unbounded<DateOnly> expected)
        {
            var actual = left.AddYears(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<DateOnly>, Unbounded<DateOnly>, Unbounded<int>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left.DayNumber - _right.DayNumber);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void DateOnly_Substract_ReturnsExpected(Unbounded<DateOnly> left, Unbounded<DateOnly> right, Unbounded<int> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
