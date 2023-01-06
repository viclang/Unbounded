namespace InfinityComparable.Tests
{
    public class InfinityDateTimeTests
    {
        private static readonly DateTime _left = new DateTime(2023, 1, 2);
        private static readonly DateTime _rightDateTime = new DateTime(2023, 1, 1);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly TimeSpan _zeroTimeSpan = TimeSpan.Zero;
        private static readonly DateTime _zeroDateTime = new DateTime();

        public static TheoryData<Infinity<DateTime>, Infinity<TimeSpan>, Infinity<DateTime>> AddData =
            new()
            {
                { new(_left), new(_rightTimeSpan), new(_left + _rightTimeSpan) },
                { new(false), new(_rightTimeSpan), new(false) },
                { new(true), new(_rightTimeSpan), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zeroTimeSpan), new(false) },
                { new(true), new(_zeroTimeSpan), new(true) },
                { new(_zeroDateTime), new(false), new(false) },
                { new(_zeroDateTime), new(true), new(true) },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(false) },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(AddData))]
        public void DateTime_Add_ReturnsExpected(Infinity<DateTime> left, Infinity<TimeSpan> right, Infinity<DateTime> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<DateTime>, Infinity<TimeSpan>, Infinity<DateTime>> SubstractTimeSpanData =
            new()
            {
                { new(_left), new(_rightTimeSpan), new(_left - _rightTimeSpan) },
                { new(false), new(_rightTimeSpan), new(false) },
                { new(true), new(_rightTimeSpan), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zeroTimeSpan), new(false) },
                { new(true), new(_zeroTimeSpan), new(true) },
                { new(_zeroDateTime), new(false), new(false) },
                { new(_zeroDateTime), new(true), new(true) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(SubstractTimeSpanData))]
        public void DateTime_SubstractTimeSpan_ReturnsExpected(Infinity<DateTime> left, Infinity<TimeSpan> right, Infinity<DateTime> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }


        public static TheoryData<Infinity<DateTime>, Infinity<DateTime>, Infinity<TimeSpan>> SubstractDateTimeData =
            new()
            {
                { new(_left), new(_rightDateTime), new(_left - _rightDateTime) },
                { new(false), new(_rightDateTime), new(false) },
                { new(true), new(_rightDateTime), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zeroDateTime), new(false) },
                { new(true), new(_zeroDateTime), new(true) },
                { new(_zeroDateTime), new(false), new(false) },
                { new(_zeroDateTime), new(true), new(true) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(SubstractDateTimeData))]
        public void DateTime_SubstractDateTime_ReturnsExpected(Infinity<DateTime> left, Infinity<DateTime> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
