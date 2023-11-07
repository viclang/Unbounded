using Unbounded.Tests.Factories;

namespace Unbounded.Tests;

public class UnboundedDecimalTests
{
    private const decimal _left = 2;
    private const decimal _right = 1;

    public static TheoryData<Unbounded<decimal>, Unbounded<decimal>, Unbounded<decimal>> AddData =
        UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

    [Theory]
    [MemberData(nameof(AddData))]
    public void Decimal_Add_ReturnsExpected(Unbounded<decimal> left, Unbounded<decimal> right, Unbounded<decimal> expected)
    {
        var actual = left.Add(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<decimal>, Unbounded<decimal>, Unbounded<decimal>> SubstractData =
        UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

    [Theory]
    [MemberData(nameof(SubstractData))]
    public void Decimal_Substract_ReturnsExpected(Unbounded<decimal> left, Unbounded<decimal> right, Unbounded<decimal> expected)
    {
        var actual = left.Substract(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<decimal>, Unbounded<decimal>, Unbounded<decimal>> MultiplyData =
        UnboundedMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

    [Theory]
    [MemberData(nameof(MultiplyData))]
    public void Decimal_Multiply_ReturnsExpected(Unbounded<decimal> left, Unbounded<decimal> right, Unbounded<decimal> expected)
    {
        var actual = left.Multiply(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<decimal>, Unbounded<decimal>, Unbounded<decimal>> DivideData =
        UnboundedMathDataFactory.CreateDivideData(_left, _right, _left / _right);

    [Theory]
    [MemberData(nameof(DivideData))]
    public void Decimal_Divide_ReturnsExpected(Unbounded<decimal> left, Unbounded<decimal> right, Unbounded<decimal> expected)
    {
        var actual = left.Divide(right);

        actual.Should().Be(expected);
    }
}
