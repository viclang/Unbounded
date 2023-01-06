namespace InfinityComparable.Tests
{
    public class InfinityDoubleTests
    {
        private const double _left = 2;
        private const double _right = 1;
        private const double _zero = 0;

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> AddData =
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
        public void Double_Add_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> SubstractData =
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
        public void Double_Substract_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> MultiplyData =
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
        public void Double_Multiply_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> DivideData =
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
        public void Double_Divide_ReturnsExpected(Infinity<double> left, Infinity<double> right, Infinity<double> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
