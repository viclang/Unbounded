namespace InfinityComparable.Tests
{
    public class InfinitySingleTests
    {
        private const float _left = 2;
        private const float _right = 1;
        private const float _zero = 0;

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> AddData =
            new()
            {
                { new(_left), new(_right), new(_left + _right) },
                { new(false), new(_right), new(false) },
                { new(true), new(_right), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zero), new(false) },
                { new(true), new(_zero), new(true) },
                { new(_zero), new(false), new(false) },
                { new(_zero), new(true), new(true) },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(false) },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(AddData))]
        public void Single_Add_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> SubstractData =
            new()
            {
                { new(_left), new(_right), new(_left - _right) },
                { new(false), new(_right), new(false) },
                { new(true), new(_right), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zero), new(false) },
                { new(true), new(_zero), new(true) },
                { new(_zero), new(false), new(false) },
                { new(_zero), new(true), new(true) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(SubstractData))]
        public void Single_Substract_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> MultiplyData =
            new()
            {
                { new(_left), new(_right), new(_left * _right) },
                { new(false), new(_right), new(false) },
                { new(true), new(_right), new(true) },
                { new(_left), new(false), new(false) },
                { new(_left), new(true), new(true) },
                { new(false), new(_zero), new() },
                { new(true), new(_zero), new() },
                { new(_zero), new(false), new() },
                { new(_zero), new(true), new() },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(true) },
                { new(false), new(true), new(false) },
                { new(true), new(false), new(false) },
            };

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Single_Multiply_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> DivideData =
            new()
            {
                { new(_left), new(_right), new(_left / _right) },
                { new(false), new(_right), new(true) },
                { new(true), new(_right), new(true) },
                { new(_left), new(false), new(_zero) },
                { new(_left), new(true), new(_zero) },
                { new(false), new(_zero), new(true) },
                { new(true), new(_zero), new(true) },
                { new(_zero), new(false), new(_zero) },
                { new(_zero), new(true), new(_zero) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Single_Divide_ReturnsExpected(Infinity<float> left, Infinity<float> right, Infinity<float> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
