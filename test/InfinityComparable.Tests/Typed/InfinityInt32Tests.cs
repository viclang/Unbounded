namespace InfinityComparable.Tests
{
    public class InfinityInt32Tests
    {
        private const int _left = 2;
        private const int _right = 1;
        private const int _zero = 0;

        public static TheoryData<Infinity<int>, Infinity<int>, Infinity<int>> AddData =
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
        public void Int32_Add_ReturnsExpected(Infinity<int> left, Infinity<int> right, Infinity<int> expected)
        {
            var actual = left.Add(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<int>, Infinity<int>, Infinity<int>> SubstractData =
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
        public void Int32_Substract_ReturnsExpected(Infinity<int> left, Infinity<int> right, Infinity<int> expected)
        {
            var actual = left.Substract(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<int>, Infinity<int>, Infinity<int>> MultiplyData =
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
        public void Int32_Multiply_ReturnsExpected(Infinity<int> left, Infinity<int> right, Infinity<int> expected)
        {
            var actual = left.Multiply(right);

            actual.Should().Be(expected);
        }

        public static TheoryData<Infinity<int>, Infinity<int>, Infinity<int>> DivideData =
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
        public void Int32_Divide_ReturnsExpected(Infinity<int> left, Infinity<int> right, Infinity<int> expected)
        {
            var actual = left.Divide(right);

            actual.Should().Be(expected);
        }
    }
}
