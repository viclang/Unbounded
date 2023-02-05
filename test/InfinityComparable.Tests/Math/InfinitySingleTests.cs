using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinitySingleTests
    {
        private const float _left = 2;
        private const float _right = 1;

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _right, _left + _right);

        [Theory]
        [MemberData(nameof(AddData))]
        public void Single_Add_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> SubstractData =
            InfinityMathDataFactory.CreateSubstractData(_left, _right, _left - _right);

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Single_Substract_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> MultiplyData =
            InfinityMathDataFactory.CreateMultiplyData(_left, _right, _left * _right);

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Single_Multiply_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> DivideData =
            InfinityMathDataFactory.CreateDivideData(_left, _right, _left / _right);

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Single_Divide_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
