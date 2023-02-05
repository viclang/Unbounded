namespace InfinityComparable.Tests
{
    public class InfinityDateTimeTests : InfinityDateTimeTestsBase
    {
        [Theory]
        [MemberData(nameof(AddData))]
        public void DateTime_Add_ReturnsExpected(Infinity<DateTime> left, Infinity<TimeSpan> right, Infinity<DateTime> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SubstractTimeSpanData))]
        public void DateTime_SubstractTimeSpan_ReturnsExpected(Infinity<DateTime> left, Infinity<TimeSpan> right, Infinity<DateTime> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMillisecondsData))]
        public void DateTime_AddMilliseconds_ReturnsExpected(Infinity<DateTime> left, Infinity<double> right, Infinity<DateTime> expected)
        {
            var actual = left.AddMilliseconds(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddSecondsData))]
        public void DateTime_AddSeconds_ReturnsExpected(Infinity<DateTime> left, Infinity<double> right, Infinity<DateTime> expected)
        {
            var actual = left.AddSeconds(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMinutesData))]
        public void DateTime_AddMinutes_ReturnsExpected(Infinity<DateTime> left, Infinity<double> right, Infinity<DateTime> expected)
        {
            var actual = left.AddMinutes(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddHoursData))]
        public void DateTime_AddHours_ReturnsExpected(Infinity<DateTime> left, Infinity<double> right, Infinity<DateTime> expected)
        {
            var actual = left.AddHours(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddDaysData))]
        public void DateTime_AddDays_ReturnsExpected(Infinity<DateTime> left, Infinity<double> right, Infinity<DateTime> expected)
        {
            var actual = left.AddDays(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMonthsData))]
        public void DateTime_AddMonths_ReturnsExpected(Infinity<DateTime> left, Infinity<int> right, Infinity<DateTime> expected)
        {
            var actual = left.AddMonths(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddYearsData))]
        public void DateTime_AddYears_ReturnsExpected(Infinity<DateTime> left, Infinity<int> right, Infinity<DateTime> expected)
        {
            var actual = left.AddYears(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddTicksData))]
        public void DateTime_AddTicks_ReturnsExpected(Infinity<DateTime> left, Infinity<long> right, Infinity<DateTime> expected)
        {
            var actual = left.AddTicks(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SubstractDateTimeData))]
        public void DateTime_SubstractDateTime_ReturnsExpected(Infinity<DateTime> left, Infinity<DateTime> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
