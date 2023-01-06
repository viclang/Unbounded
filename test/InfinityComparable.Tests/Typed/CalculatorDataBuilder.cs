using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable.Tests.Calculator
{
    public record struct CalculatorDataBuilder<TLeft, TRight, TResult>(TLeft Left, TRight Right, TResult Result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
    {
        public TheoryData<Infinity<TLeft>, Infinity<TRight>, Infinity<TResult>> Build()
            => new()
            {
                { new(Left), new(Right), new(Result) },
                { new(false), new(Right), new(false) },
                { new(true), new(Right), new(true) },
                { new(Left), new(false), new(false) },
                { new(Left), new(true), new(true) },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(false) },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };
    }
}
