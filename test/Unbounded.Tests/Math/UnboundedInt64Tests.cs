﻿using Unbounded.Tests.Factories;

namespace Unbounded.Tests;

public class UnboundedInt64Tests
{
    private const long _left = 2;
    private const long _right = 1;

    public static TheoryData<Unbounded<long>, Unbounded<long>, Unbounded<long>> AddData =
        UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

    [Theory]
    [MemberData(nameof(AddData))]
    public void Int64_Add_ReturnsExpected(Unbounded<long> left, Unbounded<long> right, Unbounded<long> expected)
    {
        var actual = left.Add(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<long>, Unbounded<long>, Unbounded<long>> SubstractData =
        UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

    [Theory]
    [MemberData(nameof(SubstractData))]
    public void Int64_Substract_ReturnsExpected(Unbounded<long> left, Unbounded<long> right, Unbounded<long> expected)
    {
        var actual = left.Substract(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<long>, Unbounded<long>, Unbounded<long>> MultiplyData =
        UnboundedMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

    [Theory]
    [MemberData(nameof(MultiplyData))]
    public void Int64_Multiply_ReturnsExpected(Unbounded<long> left, Unbounded<long> right, Unbounded<long> expected)
    {
        var actual = left.Multiply(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<long>, Unbounded<long>, Unbounded<long>> DivideData =
        UnboundedMathDataFactory.CreateDivideData(_left, _right, _left / _right);

    [Theory]
    [MemberData(nameof(DivideData))]
    public void Int64_Divide_ReturnsExpected(Unbounded<long> left, Unbounded<long> right, Unbounded<long> expected)
    {
        var actual = left.Divide(right);

        actual.Should().Be(expected);
    }
}
