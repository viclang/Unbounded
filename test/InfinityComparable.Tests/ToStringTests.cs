using FluentAssertions.Execution;

namespace UnboundedType.Tests
{
    public class ToStringTests
    {
        [Fact]
        public void ToStringDefault_ShouldBeExpected()
        {
            // Arrange
            var positiveInfinity = Unbounded<int>.PositiveInfinity;
            var negativeInfinity = Unbounded<int>.NegativeInfinity;
            var finite = new Unbounded<int>(1);

            // Act
            var actualPositiveInfinity = positiveInfinity.ToString();
            var actualNegativeInfinity = negativeInfinity.ToString();
            var actualFinite = finite.ToString();

            // Assert
            using (new AssertionScope())
            {
                actualPositiveInfinity.Should().Be("Infinity");
                actualNegativeInfinity.Should().Be("-Infinity");
                actualFinite.Should().Be("1");
            }
        }

        //[Fact]
        //public void ToStringCustom_ShouldBeExpected()
        //{
        //    // Arrange
        //    var positiveInfinity = Unbounded<int>.PositiveInfinity;
        //    var negativeInfinity = Unbounded<int>.NegativeInfinity;
        //    var finite = Inf<int>(1);

        //    // Act
        //    var actualPositiveInfinity = positiveInfinity.ToString(fin => fin.ToString());
        //    var actualNegativeInfinity = negativeInfinity.ToString(fin => fin.ToString());
        //    var actualFinite = finite.ToString(fin => fin.ToString("0.0"));

        //    // Assert
        //    using (new AssertionScope())
        //    {
        //        actualPositiveInfinity.Should().Be("Infinity");
        //        actualNegativeInfinity.Should().Be("-Infinity");
        //        actualFinite.Should().Be("1,0");
        //    }
        //}
    }
}
