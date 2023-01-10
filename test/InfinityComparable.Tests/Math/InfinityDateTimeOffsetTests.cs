namespace InfinityComparable.Tests
{
    public class InfinityDateTimeOffsetTests : InfinityDateTimeOffsetTestsBase
    {
        [Theory]
        [MemberData(nameof(AddData))]
        public void DateTimeOffset_Add_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<TimeSpan> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMillisecondsData))]
        public void DateTimeOffset_AddMilliseconds_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<double> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddMilliseconds(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddSecondsData))]
        public void DateTimeOffset_AddSeconds_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<double> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddSeconds(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMinutesData))]
        public void DateTimeOffset_AddMinutes_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<double> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddMinutes(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddHoursData))]
        public void DateTimeOffset_AddHours_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<double> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddHours(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddDaysData))]
        public void DateTimeOffset_AddDays_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<double> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddDays(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMonthsData))]
        public void DateTimeOffset_AddMonths_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<int> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddMonths(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddYearsData))]
        public void DateTimeOffset_AddYears_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<int> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddYears(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddTicksData))]
        public void DateTimeOffset_AddTicks_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<long> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.AddTicks(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SubstractTimeSpanData))]
        public void DateTimeOffset_SubstractTimeSpan_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<TimeSpan> right, Infinity<DateTimeOffset> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SubstractDateTimeData))]
        public void DateTimeOffset_SubstractDateTimeOffset_ReturnsExpected(Infinity<DateTimeOffset> left, Infinity<DateTimeOffset> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
