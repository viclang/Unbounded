namespace Unbounded.Tests;

public class UnboundedTimeOnlyTests : UnboundedTimeOnlyTestsBase
{
    [Theory]
    [MemberData(nameof(AddData))]
    public void TimeOnly_Add_ReturnsExpected(Unbounded<TimeOnly> left, Unbounded<TimeSpan> right, Unbounded<TimeOnly> expected)
    {
        var actual = left.Add(right);

        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(AddMinutesData))]
    public void TimeOnly_AddMinutes_ReturnsExpected(Unbounded<TimeOnly> left, Unbounded<double> right, Unbounded<TimeOnly> expected)
    {
        var actual = left.AddMinutes(right);

        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(AddHoursData))]
    public void TimeOnly_AddHours_ReturnsExpected(Unbounded<TimeOnly> left, Unbounded<double> right, Unbounded<TimeOnly> expected)
    {
        var actual = left.AddHours(right);

        actual.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(SubstractTimeOnlyData))]
    public void TimeOnly_SubstractTimeOnly_ReturnsExpected(Unbounded<TimeOnly> left, Unbounded<TimeOnly> right, Unbounded<TimeSpan> expected)
    {
        var actual = left.Substract(right);

        actual.Should().Be(expected);
    }
}
