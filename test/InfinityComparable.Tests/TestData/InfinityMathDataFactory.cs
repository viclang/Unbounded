using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable.Tests.Factories
{
    public static class InfinityMathDataFactory
    {
        public static TheoryData<Infinity<TLeft>, Infinity<TRight>, Infinity<TResult>> CreateAddData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { new (left), new(right), new Infinity<TResult>(result) },
                { new (false), new(right), new Infinity<TResult>(false) },
                { new (true), new(right), new Infinity<TResult>(true) },
                { new (left), new(false), new Infinity<TResult>(false) },
                { new (left), new(true), new Infinity<TResult>(true) },
                { new (false), new(default(TRight)), new Infinity<TResult>(false) },
                { new (true), new(default(TRight)), new Infinity<TResult>(true) },
                { new (default(TLeft)), new(false), new Infinity<TResult>(false) },
                { new (default(TLeft)),new (true), new Infinity<TResult>(true) },
                { new (true), new(true), new(true) },
                { new (false), new(false), new(false) },
                { new (false), new(true), new() },
                { new (true), new(false), new() },
            };

        public static TheoryData<Infinity<TLeft>, Infinity<TRight>, Infinity<TResult>> CreateSubstractData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { new(left), new(right), new(result) },
                { new(false), new(right), new(false) },
                { new(true), new(right), new(true) },
                { new(left), new(false), new(false) },
                { new(left), new(true), new(true) },
                { new(false), new(default(TRight)), new(false) },
                { new(true), new(default(TRight)), new(true) },
                { new(default(TLeft)), new(false), new(false) },
                { new(default(TLeft)), new(true), new(true) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };

        public static TheoryData<Infinity<TLeft>, Infinity<TRight>, Infinity<TResult>> CreateMultiplyData<TLeft, TRight, TResult>(
            TLeft left,
            TRight right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { new(left), new(right), new(result) },
                { new(false), new(right), new(false) },
                { new(true), new(right), new(true) },
                { new(left), new(false), new(false) },
                { new(left), new(true), new(true) },
                { new(false), new(default(TRight)), new() },
                { new(true), new(default(TRight)), new() },
                { new(default(TLeft)), new(false), new() },
                { new(default(TLeft)), new(true), new() },
                { new(true), new(true), new(true) },
                { new(false), new(false), new(true) },
                { new(false), new(true), new(false) },
                { new(true), new(false), new(false) },
            };

        public static TheoryData<Infinity<TLeft>, Infinity<TRight>, Infinity<TResult>> CreateDivideData<TLeft, TRight, TResult>(
            TLeft left,
            TRight Right,
            TResult result)
        where TLeft : struct, IEquatable<TLeft>, IComparable<TLeft>, IComparable
        where TRight : struct, IEquatable<TRight>, IComparable<TRight>, IComparable
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
            => new()
            {
                { new(left), new(Right), new(result) },
                { new(false), new(Right), new(true) },
                { new(true), new(Right), new(true) },
                { new(left), new(false), new(default(TResult)) },
                { new(left), new(true), new(default(TResult)) },
                { new(false), new(default(TRight)), new(true) },
                { new(true), new(default(TRight)), new(true) },
                { new(default(TLeft)), new(false), new(default(TResult)) },
                { new(default(TLeft)), new(true), new(default(TResult)) },
                { new(true), new(true), new() },
                { new(false), new(false), new() },
                { new(false), new(true), new() },
                { new(true), new(false), new() },
            };
    }
}
