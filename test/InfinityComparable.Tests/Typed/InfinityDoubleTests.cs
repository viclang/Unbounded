using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityDoubleTests
    {
        private const double _left = 2;
        private const double _right = 1;

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Double_Add_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Double_Substract_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> MultiplyData =
            InfinityMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Double_Multiply_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> DivideData =
            InfinityMathDataFactory.CreateDivideData(_left, _right, _left / _right);

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Double_Divide_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
