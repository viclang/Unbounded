using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        public static Infinity<decimal> Add(this Infinity<decimal> left, Infinity<decimal> right)
            => Add(left, right, (x, y) => x + y);

        public static Infinity<decimal> Substract(this Infinity<decimal> left, Infinity<decimal> right)
            => Substract(left, right, (x, y) => x - y);

        public static Infinity<decimal> Divide(this Infinity<decimal> left, Infinity<decimal> right)
            => Divide(left, right, (x, y) => x / y);

        public static Infinity<decimal> Multiply(this Infinity<decimal> left, Infinity<decimal> right)
            => Multiply(left, right, (x, y) => x * y);
    }
}
