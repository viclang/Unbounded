using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace InfinityComparable
{
    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        internal readonly bool positive;

        [MemberNotNullWhen(false, nameof(Finite))]
        public bool IsInfinite { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal readonly T value;

        public bool IsPositiveInfinity() => IsInfinite && positive;

        public bool IsNegativeInfinity() => IsInfinite && !positive;

        public T? Finite => IsInfinite ? null : value;

        public T ValueOrDefault() => value;

        public T ValueOr(T other) => IsInfinite ? other : value;

        public static readonly Infinity<T> NegativeInfinity = new(default, true, false);

        public static readonly Infinity<T> PositiveInfinity = new(default, true, true);

        public Infinity() : this(default, true, true)
        {
        }

        public Infinity(bool positive) : this(default, true, positive)
        {
        }

        public Infinity(T? value, bool positive) : this(value.GetValueOrDefault(), !value.HasValue, positive)
        {
        }

        internal Infinity(T value, bool isInfinite, bool positive)
        {
            this.value = value;
            IsInfinite = isInfinite;
            this.positive = positive;
        }

        public bool Equals(Infinity<T> other) => IsInfinite
            ? other.IsInfinite && positive == other.positive
            : !other.IsInfinite && value.Equals(other.value);

        public override bool Equals(object? other)
        {
            return other is Infinity<T> otherInfinity && Equals(otherInfinity)
                || !IsInfinite && value.Equals(other)
                || other is double otherDouble && positive.Equals(otherDouble == double.PositiveInfinity)
                || other is float otherFloat && positive.Equals(otherFloat == float.PositiveInfinity);
        }

        public override int GetHashCode() => IsInfinite
            ? positive ? 1 : -1
            : Finite.GetHashCode();

        public int CompareTo(Infinity<T> other)
        {
            if (IsInfinite)
            {
                return other.IsInfinite
                    ? positive.CompareTo(other.positive)
                    : positive ? 1 : -1;
            }
            return other.IsInfinite
                ? other.positive ? -1 : 1
                : value.CompareTo(other.value);
        }

        public static implicit operator Infinity<T>(ValueTuple<T?, bool> value) => new(value.Item1, value.Item2);
        public static implicit operator Infinity<T>(T? value) => new(value, true);
        public static implicit operator T?(Infinity<T> value) => value.Finite;

        public static Infinity<T> operator -(Infinity<T> value) => new(value.value, value.IsInfinite, false);
        public static Infinity<T> operator +(Infinity<T> value) => new(value.value, value.IsInfinite, true);
        public static Infinity<T> operator !(Infinity<T> value) => new(value.value, value.IsInfinite, !value.positive);

        public static bool operator ==(Infinity<T> left, Infinity<T> right) => left.Equals(right);
        public static bool operator !=(Infinity<T> left, Infinity<T> right) => !left.Equals(right);
        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;
        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;
        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;
        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

        public int CompareTo(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return CompareTo(otherInfinity);
            }
            if (IsInfinite)
            {
                if (other is double otherDouble)
                {
                    return positive.CompareTo(otherDouble == double.PositiveInfinity);
                }
                if (other is float otherFloat)
                {
                    return positive.CompareTo(otherFloat == double.PositiveInfinity);
                }
                return positive ? 1 : -1;
            }
            return value.CompareTo(other);
        }

        public override string? ToString() => ToString(x => x.ToString(), Infinity.InfinityToString);

        public string? ToString(Func<T, string?> finiteToString, Func<bool, string?> infinityToString)
            => IsInfinite ? infinityToString(positive) : finiteToString(value);

        public void Deconstruct(out T? value, out bool positive)
        {
            value = Finite;
            positive = this.positive;
        }
    }
}