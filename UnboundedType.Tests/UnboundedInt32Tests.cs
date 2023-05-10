using FluentAssertions;
using UnboundedType.Tests.Factories;

namespace UnboundedType.Tests
{
    public class UnboundedInt32Tests
    {
        private const int _left = 2;
        private const int _right = 1;

        [Fact]
        public void Int32_Add_ReturnsExpected()
        {
            var result = UnboundedMathDataFactory.CreateAddData(_left, _right, _left + _right);
        }

    }
}