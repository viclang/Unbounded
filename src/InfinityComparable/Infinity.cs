using System.Diagnostics.CodeAnalysis;

namespace InfinityComparable
{
    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        internal readonly T value;

        internal readonly bool positive;

        public readonly InfinityState State;

        public T? Finite => IsFinite ? value : null;

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

        public static readonly Infinity<T> NaN = new();

        public bool IsPositiveInfinity() => IsInfinity && positive;

        public bool IsNegativeInfinity() => IsInfinity && !positive;

        public T GetValueOrDefault() => value;

        public T GetValueOrDefault(T other) => IsInfinity ? other : value;

        public bool Equals(Infinity<T> other) => value.Equals(other.value)
            && State.Equals(other.State)
            && positive.Equals(other.positive);

        public override bool Equals(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return Equals(otherInfinity);
            }
            switch (State)
            {
                case InfinityState.IsFinite:
                    return value.Equals(other);
                case InfinityState.IsInfinity:
                    if (other is double otherDouble)
                    {
                        return positive.Equals(otherDouble == double.PositiveInfinity);
                    }
                    if (other is float otherFloat)
                    {
                        return positive.Equals(otherFloat == double.PositiveInfinity);
                    }
                    return false;
                case InfinityState.IsNaN:
                    return other is double.NaN || other is float.NaN;
                default:
                    throw new NotSupportedException();
            }
        }

        public int CompareTo(Infinity<T> other) => (State, other.State) switch
        {
            (InfinityState.IsFinite, InfinityState.IsFinite) => value.CompareTo(other.value),
            (InfinityState.IsFinite, InfinityState.IsInfinity) => other.positive ? -1 : 1,
            (InfinityState.IsInfinity, InfinityState.IsInfinity) => positive.CompareTo(other.positive),
            (InfinityState.IsInfinity, InfinityState.IsFinite) => positive ? 1 : -1,
            (InfinityState.IsNaN, InfinityState.IsNaN) => 0,
            (InfinityState.IsNaN, _) => -1,
            (_, InfinityState.IsNaN) => 1,
            _ => throw new NotSupportedException()
        };

        public int CompareTo(object? other)
        {
            if (other is Infinity<T> otherInfinity)
            {
                return CompareTo(otherInfinity);
            }
            switch(State)
            {
                case InfinityState.IsFinite:
                    return other is double.NaN || other is float.NaN ? 1 : value.CompareTo(other);
                case InfinityState.IsInfinity:
                    if (other is double otherDouble)
                    {
                        return positive.CompareTo(otherDouble == double.PositiveInfinity);
                    }
                    if (other is float otherFloat)
                    {
                        return positive.CompareTo(otherFloat == double.PositiveInfinity);
                    }
                    return positive ? 1 : -1;
                case InfinityState.IsNaN:
                    return other is double.NaN || other is float.NaN ? 0 : -1;
                default:
                    throw new NotSupportedException();
            }
        }

        public static implicit operator Infinity<T>(T? value) => value.HasValue ? new(value.Value) : new(false);
        public static explicit operator T?(Infinity<T> value) => value.Finite;

        public static Infinity<T> operator -(Infinity<T> value) => value.IsInfinity ? new(false) : value;
        public static Infinity<T> operator +(Infinity<T> value) => value.IsInfinity ? new(true) : value;
        public static Infinity<T> operator !(Infinity<T> value) => value.IsInfinity ? new(!value.positive) : value;

        public static bool operator ==(Infinity<T> left, Infinity<T> right) => (!left.IsNaN || !right.IsNaN) && left.Equals(right);
        public static bool operator !=(Infinity<T> left, Infinity<T> right) => left.IsNaN && right.IsNaN || !left.Equals(right);
        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;
        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;
        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;
        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

        public override int GetHashCode() => HashCode.Combine(value, positive, State);

        public override string? ToString() => ToString(f => f.ToString());

        public string? ToString(Func<T, string?> finiteToString) => State switch
        {
            InfinityState.IsFinite => finiteToString(value),
            InfinityState.IsInfinity => positive ? Infinity.PositiveInfinityString : Infinity.NegativeInfinityString,
            InfinityState.IsNaN => "NaN",
            _ => throw new NotSupportedException()
        };

        public void Deconstruct(out InfinityState state, out T? value, out bool positive)
        {
            state = State;
            value = this.Finite;
            positive = this.positive;
        }
    }
}
