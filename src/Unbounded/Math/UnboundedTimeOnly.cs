namespace Unbounded;

public static class UnboundedTimeOnly
{
    public static Unbounded<TimeOnly> Add(this Unbounded<TimeOnly> left, Unbounded<TimeSpan> right)
        => UnboundedMathHelper.Add(left, right, (x, y) => x.Add(y));

    public static Unbounded<TimeOnly> AddMinutes(this Unbounded<TimeOnly> left, Unbounded<double> right)
        => UnboundedMathHelper.Add(left, right, (x, y) => x.AddMinutes(y));

    public static Unbounded<TimeOnly> AddHours(this Unbounded<TimeOnly> left, Unbounded<double> right)
        => UnboundedMathHelper.Add(left, right, (x, y) => x.AddHours(y));

    public static Unbounded<TimeSpan> Substract(this Unbounded<TimeOnly> left, Unbounded<TimeOnly> right)
        => UnboundedMathHelper.Substract(left, right, (x, y) => x - y);
}
