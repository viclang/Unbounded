namespace InfinityComparable.Tests
{
    public class InfinityDecimalTests
    {
        private const decimal _left = 2;
        private const decimal _right = 1;
        private const decimal _zero = 0;

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> AddData =
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
        public void Decimal_Add_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> SubstractData =
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
        public void Decimal_Substract_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> MultiplyData =
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
        public void Decimal_Multiply_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> DivideData =
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
        public void Decimal_Divide_ReturnsExpected(Infinity<decimal> left, Infinity<decimal> right, Infinity<decimal> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
