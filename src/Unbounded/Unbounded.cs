namespace Unbounded
{
    public readonly struct Unbounded<T> : IComparable<Unbounded<T>>, IComparable, IEquatable<Unbounded<T>>
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        private readonly T _finite;
        private readonly UnboundedState _state;

        public Unbounded()
        {
            _finite = default;
            _state = UnboundedState.Finite;
        }

        public Unbounded(T finite)
        {
            _finite = finite;
            _state = UnboundedState.Finite;
            if (TryGetUnboundedState(finite, out var unboundedState))
            {
                _finite = default;
                _state = unboundedState;
            }
        }

        public Unbounded(UnboundedState state)
        {
            if (!Enum.IsDefined(typeof(UnboundedState), state))
            {
                throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid UnboundedState value.");
            }

            _finite = default;
            _state = state;
        }

        private bool TryGetUnboundedState(T value, out UnboundedState unboundedState)
        {
            var typeCode = Type.GetTypeCode(typeof(T));
            if (typeCode == TypeCode.Single)
            {
                return TryGetUnboundedState((float)(object)value, out unboundedState);
            }

            if (typeCode == TypeCode.Double)
            {
                return TryGetUnboundedState((double)(object)value, out unboundedState);
            }
            unboundedState = UnboundedState.Finite;
            return false;
        }

        private bool TryGetUnboundedState(double value, out UnboundedState unboundedState)
        {
            if (double.IsFinite(value))
            {
                unboundedState = UnboundedState.Finite;
                return false;
            }

            if (double.IsNegativeInfinity(value))
            {
                unboundedState = UnboundedState.NegativeInfinity;
                return true;
            }

            if (double.IsPositiveInfinity(value))
            {
                unboundedState = UnboundedState.PositiveInfinity;
                return true;
            }

            unboundedState = UnboundedState.NaN;
            return true;
        }

        private bool TryGetUnboundedState(float value, out UnboundedState unboundedState)
        {
            if (float.IsFinite(value))
            {
                unboundedState = UnboundedState.Finite;
                return false;
            }

            if (float.IsNegativeInfinity(value))
            {
                unboundedState = UnboundedState.NegativeInfinity;
                return true;
            }

            if (float.IsPositiveInfinity(value))
            {
                unboundedState = UnboundedState.PositiveInfinity;
                return true;
            }

            unboundedState = UnboundedState.NaN;
            return true;
        }

        public UnboundedState State => _state;

        public bool IsNaN => _state is UnboundedState.NaN;
        public bool IsNegativeInfinity => _state is UnboundedState.NegativeInfinity;
        public bool IsFinite => _state is UnboundedState.Finite;
        public bool IsPositiveInfinity => _state is UnboundedState.PositiveInfinity;
        public bool IsInfinity => _state is UnboundedState.NegativeInfinity || _state is UnboundedState.PositiveInfinity;

        public object Value => _state switch
        {
            UnboundedState.Finite => _finite,
            UnboundedState.NaN
                or UnboundedState.NegativeInfinity
                or UnboundedState.PositiveInfinity => _state,
            _ => throw new InvalidOperationException(),
        };

        public T GetFiniteOrDefault() => _finite;
        public T? ToNullable() => IsFinite ? _finite : null;

        public static readonly Unbounded<T> NaN = new(UnboundedState.NaN);
        public static readonly Unbounded<T> NegativeInfinity = new(UnboundedState.NegativeInfinity);
        public static readonly Unbounded<T> PositiveInfinity = new(UnboundedState.PositiveInfinity);

        public static Unbounded<T> Parse(string value) => Parse(value, s => (T)Convert.ChangeType(s, typeof(T)));

        public static Unbounded<T> Parse(string value, Func<string, T> finiteParser)
        {
            if (string.IsNullOrEmpty(value) || value.Equals("Infinity"))
            {
                return Unbounded<T>.PositiveInfinity;
            }
            else
            {
                return value.Equals("-Infinity")
                    ? Unbounded<T>.NegativeInfinity
                    : finiteParser(value);
            }
        }

        public static bool TryParse(string value, out Unbounded<T>? result) => TryParse(value, s => (T)Convert.ChangeType(s, typeof(T)), out result);

        public static bool TryParse(string value, Func<string, T> finiteParser, out Unbounded<T>? result)
        {
            try
            {
                result = Parse(value, finiteParser);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public TResult Match<TResult>(
            Func<T, TResult> finite,
            Func<TResult> negativeInfinity,
            Func<TResult> positiveInfinity,
            Func<TResult> nan)
        {
            return _state switch
            {
                UnboundedState.NaN when nan is not null => nan(),
                UnboundedState.NegativeInfinity when negativeInfinity is not null => negativeInfinity(),
                UnboundedState.Finite when finite is not null => finite(_finite),
                UnboundedState.PositiveInfinity when positiveInfinity is not null => positiveInfinity(),
                _ => throw new InvalidOperationException(),
            };
        }

        public Unbounded<TResult> MapFinite<TResult>(Func<T, TResult> mapFunc)
            where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IComparable
        {
            if (IsFinite)
            {
                return mapFunc(_finite);
            }
            return new(_state);
        }

        public bool TryPickFinite(out T value, out UnboundedState state)
        {
            value = IsFinite ? _finite : default;
            state = _state;
            return IsFinite;
        }

        public int CompareTo(Unbounded<T> other)
        {
            if (IsFinite && other.IsFinite)
            {
                return _finite.CompareTo(other._finite);
            }
            return Math.Sign(_state.CompareTo(other._state));
        }

        public int CompareTo(object? other)
        {
            if (other is Unbounded<T> otherUnbounded)
            {
                return CompareTo(otherUnbounded);
            }
            if (other is T otherValue)
            {
                return CompareTo(new Unbounded<T>(otherValue));
            }
            throw new ArgumentException("other is not the same type as this instance.");
        }

        public bool Equals(Unbounded<T> other) => _finite.Equals(other._finite) && _state.Equals(other._state);

        public override bool Equals(object? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is Unbounded<T> unboundedOther)
            {
                return Equals(unboundedOther);
            }

            if (other is double otherDouble)
            {
                if (double.IsNaN(otherDouble))
                    return IsNaN;
                if (double.IsNegativeInfinity(otherDouble))
                    return IsNegativeInfinity;
                if (double.IsPositiveInfinity(otherDouble))
                    return IsPositiveInfinity;
            }

            if (other is float otherFloat)
            {
                if (float.IsNaN(otherFloat))
                    return IsNaN;
                if (float.IsNegativeInfinity(otherFloat))
                    return IsNegativeInfinity;
                if (float.IsPositiveInfinity(otherFloat))
                    return IsPositiveInfinity;
            }

            return _finite.Equals(other);
        }

        public override string? ToString() => ToString(f => f.ToString());

        public string? ToString(Func<T, string?> finiteToString) => State switch
        {
            UnboundedState.NaN => "NaN",
            UnboundedState.NegativeInfinity => "-Infinity",
            UnboundedState.Finite => finiteToString(_finite),
            UnboundedState.PositiveInfinity => "Infinity",
            _ => throw new InvalidOperationException()
        };

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _finite.GetHashCode();
                hash = hash * 23 + _state.GetHashCode();
                return hash;
            }
        }

        public static implicit operator Unbounded<T>(T? value) => value.HasValue ? new(value.Value) : new(UnboundedState.NegativeInfinity);
        public static implicit operator T?(Unbounded<T> value) => value._state is UnboundedState.Finite ? value._finite : null;

        public static Unbounded<T> operator -(Unbounded<T> value)
        {
            if (value.IsPositiveInfinity)
            {
                return Unbounded<T>.NegativeInfinity;
            }
            return value;
        }

        public static Unbounded<T> operator +(Unbounded<T> value)
        {
            if (value.IsNegativeInfinity)
            {
                return Unbounded<T>.PositiveInfinity;
            }
            return value;
        }

        public static bool operator ==(Unbounded<T> left, Unbounded<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Unbounded<T> left, Unbounded<T> right)
        {
            return !(left == right);
        }

        public static bool operator <(Unbounded<T> left, Unbounded<T> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Unbounded<T> left, Unbounded<T> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Unbounded<T> left, Unbounded<T> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Unbounded<T> left, Unbounded<T> right)
        {
            return left.CompareTo(right) >= 0;
        }

        public void Deconstruct(out T? value, out UnboundedState state)
        {
            value = _finite;
            state = _state;
        }
    }
}
