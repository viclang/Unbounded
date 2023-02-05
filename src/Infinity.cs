using System.Diagnostics;

namespace InfinityComparable
{
    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IComparable<T>, IComparable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;
        public T Value => IsInfinite ? throw new InvalidOperationException("Infinity object must have a value.") : _value;
        
        private readonly bool positive;
        public bool IsInfinite { get; }

        public static readonly Infinity<T> NegativeInfinity = new Infinity<T>(default, true, false);
        public static readonly Infinity<T> PositiveInfinity = new Infinity<T>(default, true, true);

        public Infinity() : this(default, true, true)
        {
        }

        public Infinity(bool positive) : this(default, true, positive)
        {
        }

        public Infinity(T? value, bool positive) : this(value.GetValueOrDefault(), value is null, positive)
        {
        }

        internal Infinity(T value, bool isInfinite, bool positive)
        {
            _value = value;
            IsInfinite = isInfinite;
            this.positive = positive;
        }

        public T? ToNullable() => (T?)this;
        public T GetValueOrDefault() => !IsInfinite ? Value : default;
        public T GetValueOrDefault(T defaultValue) => !IsInfinite ? Value : defaultValue;

        public bool Equals(Infinity<T> other) => !IsInfinite
            ? !other.IsInfinite && Value.Equals(other.Value)
            : other.IsInfinite && positive.Equals(other.positive);

        public override bool Equals(object? other)
        {
            if (other is Infinity<T> infinity)
            {
                return Equals(infinity);
            }
            if (!IsInfinite)
            {
                return Value.Equals(other);
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

        public override int GetHashCode() => !IsInfinite
            ? Value.GetHashCode()
            : positive ? 1 : -1;

        public int CompareTo(Infinity<T> other)
        {
            if(!IsInfinite)
            {
                return !other.IsInfinite
                    ? Value.CompareTo(other.Value)
                    : other.positive ? -1 : 1;
            }
            return other.IsInfinite
                ? positive.CompareTo(other.positive)
                : positive ? 1 : -1;
        }

        public int CompareTo(object? other)
        {
            if (other is Infinity<T>)
            {
                return CompareTo((Infinity<T>)other);
            }
            if (!IsInfinite)
            {
                return Value.CompareTo(other);
            }
            if (other is double)
            {
                return positive.CompareTo((double)other == double.PositiveInfinity);
            }
            if (other is float)
            {
                return positive.CompareTo((float)other == double.PositiveInfinity);
            }
            return positive ? 1 : -1;
        }

        public override string ToString() => IsInfinite
            ? positive ? "+∞" : "-∞"
            : string.Empty + Value.ToString();

        public static implicit operator Infinity<T>(ValueTuple<T?, bool> value) => new Infinity<T>(value.Item1, value.Item2);
        public static implicit operator Infinity<T>(T? value) => new Infinity<T>(value, true);
        public static implicit operator T?(Infinity<T> value) => !value.IsInfinite ? value.Value : null;
        public static bool operator ==(Infinity<T> left, T? right) => left.ToNullable().Equals(right);
        public static bool operator !=(Infinity<T> left, T? right) => left.ToNullable().Equals(right);
        public static bool operator ==(T? left, Infinity<T> right) => left.Equals(right.ToNullable());
        public static bool operator !=(T? left, Infinity<T> right) => left.Equals(right.ToNullable());

        public static bool operator ==(Infinity<T> left, Infinity<T> right) => left.Equals(right);
        public static bool operator !=(Infinity<T> left, Infinity<T> right) => !left.Equals(right);
        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;
        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;
        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;
        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

        public static Infinity<T> operator -(Infinity<T> value) => new Infinity<T>(value.GetValueOrDefault(), value.IsInfinite, false);
        public static Infinity<T> operator +(Infinity<T> value) => new Infinity<T>(value.GetValueOrDefault(), value.IsInfinite, true);
        public static Infinity<T> operator !(Infinity<T> value) => new Infinity<T>(value.GetValueOrDefault(), value.IsInfinite, !value.positive);
        
        public void Deconstruct(out T? value, out bool positive)
        {
            value = ToNullable();
            positive = this.positive;
        }
    }

    public static class Infinity
    {
        public static Infinity<T> Inf<T>(T? value = null, bool positive = true) where T : struct, IComparable<T>, IComparable
            => new Infinity<T>(value, positive);

        public static Infinity<T> Inf<T>(bool positive) where T : struct, IComparable<T>, IComparable
            => new Infinity<T>(positive);

        public static Infinity<T> Inf<T>() where T : struct, IComparable<T>, IComparable
            => new Infinity<T>();

        public static Infinity<T> ToInfinity<T>(this T? value, bool positive) where T : struct, IComparable<T>, IComparable
            => new Infinity<T>(value, positive);

        public static Infinity<T> ToPositiveInfinity<T>(this T? value) where T : struct, IComparable<T>, IComparable
            => new Infinity<T>(value, true);

        public static Infinity<T> ToNegativeInfinity<T>(this T? value) where T : struct, IComparable<T>, IComparable
            => new Infinity<T>(value, false);
    }
}