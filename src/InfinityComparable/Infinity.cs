//using System.Diagnostics.CodeAnalysis;
//using System.Diagnostics.Contracts;

//namespace InfinityComparable
//{
//    public readonly struct Infinity<T> : IEquatable<Infinity<T>>, IComparable<Infinity<T>>, IComparable
//        where T : struct, IEquatable<T>, IComparable<T>, IComparable
//    {
//        internal readonly T value;

//        internal readonly bool positive;

//        public readonly UnboundedState State;

//        [Pure]
//        public T? Finite => IsFinite ? value : null;

//        [Pure]
//        public bool IsNaN => State == UnboundedState.NaN;

//        [Pure, MemberNotNullWhen(true, nameof(Finite))]
//        public bool IsFinite => State == UnboundedState.Finite;

//        [Pure]
//        public bool IsInfinity => State == UnboundedState.IsInfinity;

//        [Pure]
//        public Infinity()
//        {
//            this.State = UnboundedState.NaN;
//            this.value = default;
//            this.positive = default;
//        }

//        [Pure]
//        public Infinity(T value)
//        {
//            this.State = UnboundedState.Finite;
//            this.value = value;
//            this.positive = default;
//        }

//        [Pure]
//        public Infinity(bool positive)
//        {
//            this.State = UnboundedState.IsInfinity;
//            this.value = default;
//            this.positive = positive;
//        }

//        public static readonly Infinity<T> NegativeInfinity = new(false);

//        public static readonly Infinity<T> PositiveInfinity = new(true);

//        public static readonly Infinity<T> NaN = new();

//        [Pure]
//        public bool IsPositiveInfinity() => IsInfinity && positive;

//        [Pure]
//        public bool IsNegativeInfinity() => IsInfinity && !positive;

//        [Pure]
//        public T GetValueOrDefault() => value;

//        [Pure]
//        public T GetValueOrDefault(T other) => IsInfinity ? other : value;

//        [Pure]
//        public bool Equals(Infinity<T> other) => value.Equals(other.value)
//            && State.Equals(other.State)
//            && positive.Equals(other.positive);

//        [Pure]
//        public override bool Equals(object? other)
//        {
//            if (other is Infinity<T> otherInfinity)
//            {
//                return Equals(otherInfinity);
//            }
//            switch (State)
//            {
//                case UnboundedState.Finite:
//                    return value.Equals(other);
//                case UnboundedState.IsInfinity:
//                    if (other is double otherDouble)
//                    {
//                        return positive.Equals(otherDouble == double.PositiveInfinity);
//                    }
//                    if (other is float otherFloat)
//                    {
//                        return positive.Equals(otherFloat == double.PositiveInfinity);
//                    }
//                    return false;
//                case UnboundedState.NaN:
//                    return other is double.NaN || other is float.NaN;
//                default:
//                    throw new NotSupportedException();
//            }
//        }

//        [Pure]
//        public int CompareTo(Infinity<T> other) => (State, other.State) switch
//        {
//            (UnboundedState.Finite, UnboundedState.Finite) => value.CompareTo(other.value),
//            (UnboundedState.Finite, UnboundedState.IsInfinity) => other.positive ? -1 : 1,
//            (UnboundedState.IsInfinity, UnboundedState.IsInfinity) => positive.CompareTo(other.positive),
//            (UnboundedState.IsInfinity, UnboundedState.Finite) => positive ? 1 : -1,
//            (UnboundedState.NaN, UnboundedState.NaN) => 0,
//            (UnboundedState.NaN, _) => -1,
//            (_, UnboundedState.NaN) => 1,
//            _ => throw new NotSupportedException()
//        };

//        [Pure]
//        public int CompareTo(object? other)
//        {
//            if (other is Infinity<T> otherInfinity)
//            {
//                return CompareTo(otherInfinity);
//            }
//            switch(State)
//            {
//                case UnboundedState.Finite:
//                    return other is double.NaN || other is float.NaN ? 1 : value.CompareTo(other);
//                case UnboundedState.IsInfinity:
//                    if (other is double otherDouble)
//                    {
//                        return positive.CompareTo(otherDouble == double.PositiveInfinity);
//                    }
//                    if (other is float otherFloat)
//                    {
//                        return positive.CompareTo(otherFloat == double.PositiveInfinity);
//                    }
//                    return positive ? 1 : -1;
//                case UnboundedState.NaN:
//                    return other is double.NaN || other is float.NaN ? 0 : -1;
//                default:
//                    throw new NotSupportedException();
//            }
//        }

//        [Pure]
//        public static implicit operator Infinity<T>(T? value) => value.HasValue ? new(value.Value) : new(false);

//        [Pure]
//        public static explicit operator T?(Infinity<T> value) => value.Finite;

//        [Pure]
//        public static Infinity<T> operator -(Infinity<T> value) => value.IsInfinity ? new(false) : value;

//        [Pure]
//        public static Infinity<T> operator +(Infinity<T> value) => value.IsInfinity ? new(true) : value;

//        [Pure]
//        public static Infinity<T> operator !(Infinity<T> value) => value.IsInfinity ? new(!value.positive) : value;

//        [Pure]
//        public static bool operator ==(Infinity<T> left, Infinity<T> right) => (!left.IsNaN || !right.IsNaN) && left.Equals(right);

//        [Pure]
//        public static bool operator !=(Infinity<T> left, Infinity<T> right) => left.IsNaN && right.IsNaN || !left.Equals(right);

//        [Pure]
//        public static bool operator >(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == 1;

//        [Pure]
//        public static bool operator <(Infinity<T> left, Infinity<T> right) => left.CompareTo(right) == -1;

//        [Pure]
//        public static bool operator >=(Infinity<T> left, Infinity<T> right) => left == right || left > right;

//        [Pure]
//        public static bool operator <=(Infinity<T> left, Infinity<T> right) => left == right || left < right;

//        [Pure]
//        public override int GetHashCode() => HashCode.Combine(value, positive, State);

//        [Pure]
//        public override string? ToString() => ToString(f => f.ToString());

//        [Pure]
//        public string? ToString(Func<T, string?> finiteToString) => State switch
//        {
//            UnboundedState.Finite => finiteToString(value),
//            UnboundedState.IsInfinity => positive ? Infinity.PositiveInfinityString : Infinity.NegativeInfinityString,
//            UnboundedState.NaN => "NaN",
//            _ => throw new NotSupportedException()
//        };

//        [Pure]
//        public void Deconstruct(out UnboundedState state, out T? value, out bool positive)
//        {
//            state = State;
//            value = this.Finite;
//            positive = this.positive;
//        }
//    }
//}
