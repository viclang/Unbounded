namespace InfinityComparable.Tests
{
    public class InfinityDateOnlyTests
    {
        private static readonly DateOnly _left = new DateOnly(2023, 1, 2);
        private static readonly DateOnly _right = new DateOnly(2023, 1, 1);
        private static readonly int _rightInt = 1;
        private static readonly DateOnly _zero = new DateOnly();
        private static readonly int _zeroInt = 0;

        public static TheoryData<Infinity<DateOnly>, Infinity<int>, Infinity<DateOnly>> AddData =
            new()
            {
                { new(_left), new(_rightInt), new(_left.AddDays(_rightInt)) },
                { new(false), new(_rightInt), new(false) },
                { new(true), new(_rightInt), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zeroInt), new(false) },
                { new(true), new(_zeroInt), new(true) },
                { new(_zero), new(false), new(false) },
                { new(_zero), new(true), new(true) },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(false) },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(AddData))]
        public void DateOnly_Add_ReturnsExpected(Infinity<DateOnly> left, Infinity<int> right, Infinity<DateOnly> expected)
        {
            var actual = left.AddDays(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<DateOnly>, Infinity<DateOnly>, Infinity<DateOnly>> SubstractDateOnlyData =
            new()
            {
                { new(_left), new(_right), new(DateOnly.FromDayNumber(_left.DayNumber - _right.DayNumber)) },
                { new(false), new(_right), new(false) },
                { new(true), new(_right), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zero), new(false) },
                { new(true), new(_zero), new(true) },
                { new(_zero), new(false), new(false) },
                { new(_zero), new(true), new(true) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(SubstractDateOnlyData))]
        public void DateOnly_SubstractDateOnly_ReturnsExpected(Infinity<DateOnly> left, Infinity<DateOnly> right, Infinity<DateOnly> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
