using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityDecimalTests
    {
        private const decimal _left = 2;
        private const decimal _right = 1;

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Decimal_Add_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Decimal_Substract_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> MultiplyData =
            InfinityMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Decimal_Multiply_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> DivideData =
            InfinityMathDataFactory.CreateDivideData(_left, _right, _left / _right);

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Decimal_Divide_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
