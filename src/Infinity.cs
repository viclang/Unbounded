using System.Text;

namespace InfinityComparable
{
    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
        where T : struct, IComparable<T>, IComparable
    {
        private readonly bool positive;
        public T? Finite { get; }
        public bool IsInfinite => Finite is null;

        public Infinity() : this(null, true)
        {
        }

        public Infinity(bool positive) : this(null, positive)
        {
        }

        public Infinity(T? value, bool positive)
        {
            Finite = value;
            this.positive = positive;
        }

        public bool Equals(Infinity<T> other)
        {
            return Finite is not null
                ? other.Finite is not null && Finite.Value.Equals(other.Finite!.Value)
                : other.IsInfinite && positive.Equals(other.positive);
        }

        public override bool Equals(object? other)
        {
            if (other is Infinity<T>)
            {
                return Equals((Infinity<T>)other);
            }
            if (Finite is not null)
            {
                return Finite!.Value.Equals(other);
            }
            if (other is double)
            {
                return positive.Equals(((double)other) == double.PositiveInfinity);
            }
            if (other is float)
            {
                return positive.Equals(((float)other) == float.PositiveInfinity);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Finite is not null
                ? Finite.GetHashCode()
                : positive ? 1 : -1;
        }

        public int CompareTo(Infinity<T> other)
        {
            if(Finite is not null)
            {
                return other.Finite is not null
                    ? Finite.Value.CompareTo(other.Finite.Value)
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
            if (Finite is not null)
            {
                return Finite.Value.CompareTo(other);
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

        public override string ToString()
        {
            return Finite is not null
                ? string.Empty + Finite.ToString()
                : positive ? "+∞" : "-∞";
        }

        public static implicit operator Infinity<T>(T? value)
        {
            return new Infinity<T>(value, true);
        }

        public static implicit operator T?(Infinity<T> value)
        {
            return value.Finite;
        }

        public static Infinity<T> operator -(Infinity<T> value)
        {
            return new Infinity<T>(value.Finite, false);
        }

        public static Infinity<T> operator +(Infinity<T> value)
        {
            return new Infinity<T>(value.Finite, true);
        }

        public static Infinity<T> operator !(Infinity<T> value)
        {
            return new Infinity<T>(value.Finite, !value.positive);
        }

        public static bool operator ==(Infinity<T> left, Infinity<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Infinity<T> left, Infinity<T> right)
        {
            return !left.Equals(right);
        }

        public static bool operator >(Infinity<T> left, Infinity<T> right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator <(Infinity<T> left, Infinity<T> right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator >=(Infinity<T> left, Infinity<T> right)
        {
            return left == right || left > right;
        }

        public static bool operator <=(Infinity<T> left, Infinity<T> right)
        {
            return left == right || left < right;
        }

        public void Deconstruct(out T? finite, out bool positive)
        {
            finite = Finite;
            positive = this.positive;
        }
    }

    public static class Infinity
    {
        public static Infinity<T> Inf<T>(T? value = null, bool positive = true)
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>(value, positive);
        }

        public static Infinity<T> Inf<T>(bool positive)
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>(positive);
        }

        public static Infinity<T> Inf<T>()
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>();
        }

        public static Infinity<T> ToInfinity<T>(this T? value, bool positive)
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>(value, positive);
        }

        public static Infinity<T> ToPositiveInfinity<T>(this T? value)
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>(value, true);
        }

        public static Infinity<T> ToNegativeInfinity<T>(this T? value)
            where T : struct, IComparable<T>, IComparable
        {
            return new Infinity<T>(value, false);
        }
    }
}