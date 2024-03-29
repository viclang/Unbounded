﻿using Unbounded.Tests.Factories;

namespace Unbounded.Tests;

public class UnboundedInt32Tests
{
    private const int _left = 2;
    private const int _right = 1;

    public static TheoryData<Unbounded<int>, Unbounded<int>, Unbounded<int>> AddData =
        UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

    [Theory]
    [MemberData(nameof(AddData))]
    public void Int32_Add_ReturnsExpected(Unbounded<int> left, Unbounded<int> right, Unbounded<int> expected)
    {
        var actual = left.Add(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<int>, Unbounded<int>, Unbounded<int>> SubstractData =
        UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

    [Theory]
    [MemberData(nameof(SubstractData))]
    public void Int32_Substract_ReturnsExpected(Unbounded<int> left, Unbounded<int> right, Unbounded<int> expected)
    {
        var actual = left.Substract(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<int>, Unbounded<int>, Unbounded<int>> MultiplyData =
        UnboundedMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

    [Theory]
    [MemberData(nameof(MultiplyData))]
    public void Int32_Multiply_ReturnsExpected(Unbounded<int> left, Unbounded<int> right, Unbounded<int> expected)
    {
        var actual = left.Multiply(right);

        actual.Should().Be(expected);
    }

    public static TheoryData<Unbounded<int>, Unbounded<int>, Unbounded<int>> DivideData =
        UnboundedMathDataFactory.CreateDivideData(_left, _right, _left / _right);

    [Theory]
    [MemberData(nameof(DivideData))]
    public void Int32_Divide_ReturnsExpected(Unbounded<int> left, Unbounded<int> right, Unbounded<int> expected)
    {
        var actual = left.Divide(right);

        actual.Should().Be(expected);
    }
}
