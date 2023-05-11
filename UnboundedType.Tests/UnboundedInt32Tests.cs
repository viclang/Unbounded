using FluentAssertions;
using UnboundedType.Tests.Factories;

namespace UnboundedType.Tests
{
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

    }
}