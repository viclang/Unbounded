﻿using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityInt64Tests
    {
        private const long _left = 2;
        private const long _right = 1;

        public static TheoryData<Infinity<long>, Infinity<long>, Infinity<long>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Int64_Add_ReturnsExpected(Infinity<long> left, Infinity<long> right, Infinity<long> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<long>, Infinity<long>, Infinity<long>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Int64_Substract_ReturnsExpected(Infinity<long> left, Infinity<long> right, Infinity<long> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<long>, Infinity<long>, Infinity<long>> MultiplyData =
            InfinityMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Int64_Multiply_ReturnsExpected(Infinity<long> left, Infinity<long> right, Infinity<long> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<long>, Infinity<long>, Infinity<long>> DivideData =
            InfinityMathDataFactory.CreateDivideData(_left, _right, _left / _right);

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Int64_Divide_ReturnsExpected(Infinity<long> left, Infinity<long> right, Infinity<long> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
