using System.Diagnostics.CodeAnalysis;

namespace InfinityComparable
{
    public struct Infinity<T> : IInfinity<T>, IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        internal readonly T value;

        internal readonly bool positive;

        public T? Finite => IsFinite ? value : null;

        public InfinityState State { get; }

        public bool IsNaN => State == InfinityState.IsNaN;

        [MemberNotNullWhen(true, nameof(Finite))]
        public bool IsFinite => State == InfinityState.IsFinite;

        public bool IsInfinity => State == InfinityState.IsInfinity;

        public Infinity()
        {
            this.State = InfinityState.IsNaN;
            this.value = default;
            this.positive = default;
        }

        public Infinity(T value)
        {
            this.State = InfinityState.IsFinite;
            this.value = value;
            this.positive = default;
        }

        public Infinity(bool positive)
        {
            this.State = InfinityState.IsInfinity;
            this.value = default;
            this.positive = positive;
        }

        public static readonly Infinity<T> NegativeInfinity = new(false);

        public static readonly Infinity<T> PositiveInfinity = new(true);

        public bool IsPositiveInfinity() => IsInfinity && positive;

        public bool IsNegativeInfinity() => IsInfinity && !positive;

        public T GetValueOrDefault() => value;

        public T GetValueOrDefault(T other) => IsInfinity ? other : value;

        public bool Equals(Infinity<T> other) => State == InfinityState.IsInfinity
            ? other.IsInfinity && positive == other.positive
            : other.IsFinite && value.Equals(other.value);

        public override bool Equals(object? other)
        {
            return other is Infinity<T> otherInfinity && Equals(otherInfinity)
                || IsFinite && value.Equals(other)
                || other is double otherDouble && positive.Equals(otherDouble == double.PositiveInfinity)
                || other is float otherFloat && positive.Equals(otherFloat == float.PositiveInfinity);
        }

        public int CompareTo(Infinity<T> other) => (State, other.State) switch
        {
            (InfinityState.IsFinite, InfinityState.IsFinite) => value.CompareTo(other.value),
            (InfinityState.IsFinite, InfinityState.IsInfinity) => other.positive ? -1 : 1,
            (InfinityState.IsInfinity, InfinityState.IsInfinity) => positive.CompareTo(other.positive),
            (InfinityState.IsInfinity, InfinityState.IsFinite) => positive ? 1 : -1,
            _ => throw new NotImplementedException()
        };

        public int CompareTo(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return CompareTo(otherInfinity);
            }
            if (IsFinite)
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

        public static implicit operator Infinity<T>(T? value) => value.HasValue ? new(value.Value) : new(false);
        public static explicit operator T?(Infinity<T> value) => value.Finite;

        public static Infinity<T> operator -(Infinity<T> value) => value.IsInfinity ? new(false) : value;
        public static Infinity<T> operator +(Infinity<T> value) => value.IsInfinity ? new(true) : value;
        public static Infinity<T> operator !(Infinity<T> value) => value.IsInfinity ? new(!value.positive) : value;

        public static bool operator ==(Infinity<T> left, Infinity<T> right) => left.Equals(right);
        public static bool operator !=(Infinity<T> left, Infinity<T> right) => !left.Equals(right);
        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;
        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;
        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;
        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

        public override int GetHashCode() => State switch
        {
            InfinityState.IsFinite => value.GetHashCode(),
            InfinityState.IsInfinity => positive.GetHashCode(),
            _ => throw new NotImplementedException(),
        };

        public override string? ToString() => ToString(Infinity.InfinityToString);

        public string? ToString(Func<bool, string?> infinityToString) => ToString(x => x.ToString(), infinityToString);

        public string? ToString(Func<T, string?> finiteToString, Func<bool, string?> infinityToString) => State switch
        {
            InfinityState.IsFinite => finiteToString(value),
            InfinityState.IsInfinity => infinityToString(positive),
            InfinityState.IsNaN => "NaN",
            _ => throw new NotImplementedException()
        };

        public void Deconstruct(out InfinityState state, out T value, out bool positive)
        {
            state = State;
            value = this.value;
            positive = this.positive;
        }
    }
}
