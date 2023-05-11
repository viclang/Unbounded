using Unbounded.Tests.Factories;

namespace Unbounded.Tests
{
    public class UnboundedDoubleTests
    {
        private const double _left = 2;
        private const double _right = 1;

        public static TheoryData<Unbounded<double>, Unbounded<double>, Unbounded<double>> AddData =
            UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Double_Add_ReturnsExpected(Unbounded<double> left, Unbounded<double> right, Unbounded<double> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<double>, Unbounded<double>, Unbounded<double>> SubstractData =
            UnboundedMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Double_Substract_ReturnsExpected(Unbounded<double> left, Unbounded<double> right, Unbounded<double> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<double>, Unbounded<double>, Unbounded<double>> MultiplyData =
            UnboundedMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Double_Multiply_ReturnsExpected(Unbounded<double> left, Unbounded<double> right, Unbounded<double> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Unbounded<double>, Unbounded<double>, Unbounded<double>> DivideData =
            UnboundedMathDataFactory.CreateDivideData(_left, _right, _left / _right);

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Double_Divide_ReturnsExpected(Unbounded<double> left, Unbounded<double> right, Unbounded<double> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
