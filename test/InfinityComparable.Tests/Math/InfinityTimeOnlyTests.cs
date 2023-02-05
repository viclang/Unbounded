using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityTimeOnlyTests : InfinityTimeOnlyTestsBase
    {
        [Theory]
        [MemberData(nameof(AddData))]
        public void TimeOnly_Add_ReturnsExpected(Infinity<TimeOnly> left, Infinity<TimeSpan> right, Infinity<TimeOnly> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddMinutesData))]
        public void TimeOnly_AddMinutes_ReturnsExpected(Infinity<TimeOnly> left, Infinity<double> right, Infinity<TimeOnly> expected)
        {
            var actual = left.AddMinutes(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(AddHoursData))]
        public void TimeOnly_AddHours_ReturnsExpected(Infinity<TimeOnly> left, Infinity<double> right, Infinity<TimeOnly> expected)
        {
            var actual = left.AddHours(right);

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SubstractTimeOnlyData))]
        public void TimeOnly_SubstractTimeOnly_ReturnsExpected(Infinity<TimeOnly> left, Infinity<TimeOnly> right, Infinity<TimeSpan> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }
    }
}
