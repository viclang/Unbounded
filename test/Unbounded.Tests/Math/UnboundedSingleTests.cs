using Unbounded.Tests.Factories;

namespace Unbounded.Tests;

public class UnboundedSingleTests
{
    private const float _left = 2;
    private const float _right = 1;

    public static TheoryData<Unbounded<float>, Unbounded<float>, Unbounded<float>> AddData =
        UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

    [Theory]
    [MemberData(nameof(AddData))]
    public void Single_Add_ReturnsExpected(Unbounded<float> left, Unbounded<float> right, Unbounded<float> expected)
    {
        var actual = left.Add(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<float>, Unbounded<float>, Unbounded<float>> SubstractData =
        UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

    [Theory]
    [MemberData(nameof(SubstractData))]
    public void Single_Substract_ReturnsExpected(Unbounded<float> left, Unbounded<float> right, Unbounded<float> expected)
    {
        var actual = left.Substract(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<float>, Unbounded<float>, Unbounded<float>> MultiplyData =
        UnboundedMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

    [Theory]
    [MemberData(nameof(MultiplyData))]
    public void Single_Multiply_ReturnsExpected(Unbounded<float> left, Unbounded<float> right, Unbounded<float> expected)
    {
        var actual = left.Multiply(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<float>, Unbounded<float>, Unbounded<float>> DivideData =
        UnboundedMathDataFactory.CreateDivideData(_left, _right, _left / _right);

    [Theory]
    [MemberData(nameof(DivideData))]
    public void Single_Divide_ReturnsExpected(Unbounded<float> left, Unbounded<float> right, Unbounded<float> expected)
    {
        var actual = left.Divide(right);

        actual.Should().Be(expected);
    }
}
