using System.Diagnostics.Contracts;

namespace UnboundedType
{
    public static partial class Unbounded
    {
        [Pure]
        public static Unbounded<TimeSpan> Add(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => Add(left, right, (x, y) => x + y);

        [Pure]
        public static Unbounded<TimeSpan> Substract(this Unbounded<TimeSpan> left, Unbounded<TimeSpan> right)
            => Substract(left, right, (x, y) => x - y);
    }
}
