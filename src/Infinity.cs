using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace InfinityComparable
{
    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IComparable<T>, IComparable
    {
        private readonly bool positive;

        [MemberNotNullWhen(true, nameof(Finite))]
        public bool HasValue { get; }

        [MemberNotNullWhen(false, nameof(Finite))]
        public bool IsInfinite() => !HasValue;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T value;
        public T? Finite => HasValue ? value : null;
        public T FiniteOrDefault() => value;
        public T FiniteOr(T other) => HasValue ? value : other;

        public static readonly Infinity<T> NegativeInfinity = new(default, false, false);
        public static readonly Infinity<T> PositiveInfinity = new(default, false, true);

        public Infinity() : this(default, false, true)
        {
        }

        public Infinity(bool positive) : this(default, false, positive)
        {
        }

        public Infinity(T? value, bool positive) : this(value.GetValueOrDefault(), value.HasValue, positive)
        {
        }

        internal Infinity(T value, bool hasValue, bool positive)
        {
            this.value = value;
            HasValue = hasValue;
            this.positive = positive;
        }

        public bool Equals(Infinity<T> other) => HasValue
            ? other.HasValue && Finite.Equals(other.Finite)
            : !other.HasValue && positive.Equals(other.positive);

        public override bool Equals(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return Equals(otherInfinity);
            }
            if (HasValue)
            {
                return Finite.Equals(other);
            }
            if (other is double otherDouble)
            {
                return positive.Equals(otherDouble == double.PositiveInfinity);
            }
            if (other is float otherFloat)
            {
                return positive.Equals(otherFloat == float.PositiveInfinity);
            }
            return false;
        }

        public override int GetHashCode() => HasValue
            ? Finite.GetHashCode()
            : positive ? 1 : -1;

        public int CompareTo(Infinity<T> other)
        {
            if(HasValue)
            {
                return other.HasValue
                    ? value.CompareTo(other.value)
                    : other.positive ? -1 : 1;
            }
            return other.HasValue
                ? positive ? 1 : -1
                : positive.CompareTo(other.positive);
        }

        public int CompareTo(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return CompareTo(otherInfinity);
            }
            if (HasValue)
            {
                return value.CompareTo(other);
            }
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

        public override string ToString() => HasValue
            ? string.Empty + Finite.ToString()
            : positive ? "Infinity" : "-Infinity";

        public static implicit operator Infinity<T>(ValueTuple<T?, bool> value) => new(value.Item1, value.Item2);
        public static implicit operator Infinity<T>(T? value) => new(value, true);
        public static implicit operator T?(Infinity<T> value) => value.Finite;

        public static Infinity<T> operator -(Infinity<T> value) => new(value.value, value.HasValue, false);
        public static Infinity<T> operator +(Infinity<T> value) => new(value.value, value.HasValue, true);
        public static Infinity<T> operator !(Infinity<T> value) => new(value.value, value.HasValue, !value.positive);

        public static bool operator ==(Infinity<T> left, Infinity<T> right) => left.Equals(right);
        public static bool operator !=(Infinity<T> left, Infinity<T> right) => !left.Equals(right);
        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;
        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;
        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;
        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

        public void Deconstruct(out T? value, out bool positive)
        {
            value = Finite;
            positive = this.positive;
        }
    }

    public static class Infinity
    {
        public static Infinity<T> Inf<T>(T? value = null, bool positive = true) where T : struct, IComparable<T>, IComparable
            => new(value, positive);

        public static Infinity<T> Inf<T>(bool positive) where T : struct, IComparable<T>, IComparable
            => new(positive);

        public static Infinity<T> Inf<T>() where T : struct, IComparable<T>, IComparable
            => new();

        public static Infinity<T> ToInfinity<T>(this T? value, bool positive) where T : struct, IComparable<T>, IComparable
            => new(value, positive);

        public static Infinity<T> ToPositiveInfinity<T>(this T? value) where T : struct, IComparable<T>, IComparable
            => new(value, true);

        public static Infinity<T> ToNegativeInfinity<T>(this T? value) where T : struct, IComparable<T>, IComparable
            => new(value, false);
    }
}