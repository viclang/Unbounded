using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Unbounded;

public readonly struct Unbounded<T>
    : IComparable<Unbounded<T>>,
      IEquatable<Unbounded<T>>,
      IComparisonOperators<Unbounded<T>, Unbounded<T>, bool>,
      IUnaryNegationOperators<Unbounded<T>, Unbounded<T>>,
      IUnaryPlusOperators<Unbounded<T>, Unbounded<T>>,
      IParsable<Unbounded<T>>,
      ISpanParsable<Unbounded<T>>
    where T : struct, IEquatable<T>, IComparable<T>, ISpanParsable<T>
{
    private readonly T _finite;
    private readonly UnboundedState _state;

    public Unbounded()
    {
        _state = UnboundedState.Finite;
    }

    public Unbounded(T value)
    {
        _state = value switch
        {
            float.PositiveInfinity or double.PositiveInfinity => UnboundedState.PositiveInfinity,
            float.NegativeInfinity or double.NegativeInfinity => UnboundedState.NegativeInfinity,
            float.NaN or double.NaN => UnboundedState.None,
            _ => UnboundedState.Finite
        };
        _finite = value;
    }

    public Unbounded(UnboundedState state)
    {
        _finite = default;
        _state = state;
    }

    public UnboundedState State => _state;
    public bool IsNone => _state is UnboundedState.None;
    public bool IsNegativeInfinity => _state is UnboundedState.NegativeInfinity;
    public bool IsFinite => _state is UnboundedState.Finite;
    public bool IsPositiveInfinity => _state is UnboundedState.PositiveInfinity;
    public bool IsInfinity => _state is UnboundedState.NegativeInfinity or UnboundedState.PositiveInfinity;

    public T GetValueOrDefault() => _finite;
    public T? ToNullable() => _finite switch
    {
        float.NegativeInfinity or float.PositiveInfinity or float.NaN or
        double.NegativeInfinity or double.PositiveInfinity or double.NaN => _finite,
        _ => IsFinite ? _finite : null,
    };

    public static readonly Unbounded<T> None = new(UnboundedState.None);

    public static readonly Unbounded<T> NegativeInfinity = new(UnboundedState.NegativeInfinity);

    public static readonly Unbounded<T> PositiveInfinity = new(UnboundedState.PositiveInfinity);

    public TResult Match<TResult>(
        Func<T, TResult> finite,
        Func<Unbounded<T>, TResult> negativeInfinity,
        Func<Unbounded<T>, TResult> positiveInfinity,
        Func<Unbounded<T>, TResult> none)
    {
        return _state switch
        {
            UnboundedState.None when none is not null => none(this),
            UnboundedState.NegativeInfinity when negativeInfinity is not null => negativeInfinity(this),
            UnboundedState.Finite when finite is not null => finite(_finite),
            UnboundedState.PositiveInfinity when positiveInfinity is not null => positiveInfinity(this),
            _ => throw new InvalidOperationException(),
        };
    }

    public Unbounded<TResult> MapFinite<TResult>(Func<T, TResult> mapFunc)
        where TResult : struct, IEquatable<TResult>, IComparable<TResult>, IParsable<TResult>, ISpanParsable<TResult>
    {
        if (IsFinite)
        {
            return new(mapFunc(_finite));
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

    public bool Equals(Unbounded<T> other)
    {
        return IsFinite ? _finite.Equals(other._finite) : _state.Equals(other._state);
    }

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
        if (other is T otherValue)
        {
            return Equals(new Unbounded<T>(otherValue));
        }
        return false;
    }

    public override string? ToString() => ToString(f => f.ToString());

    public string? ToString(Func<T, string?> finiteToString) => State switch
    {
        UnboundedState.None => "None",
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

    public static implicit operator Unbounded<T>(T? value) => value.HasValue ? new(value.Value) : new(UnboundedState.None);
    public static explicit operator T?(Unbounded<T> value) => value.ToNullable();

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
        return !left.Equals(right);
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

    public static Unbounded<T> Parse(string s, IFormatProvider? provider = default)
    {
        return Parse(s.AsSpan(), provider);
    }

    public static Unbounded<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider = default)
    {
        if (TryParseUnbounded(s, out var result))
        {
            return result;
        }
        return new(T.Parse(s, provider));
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Unbounded<T> result)
    {
        return TryParse(s.AsSpan(), provider, out result);
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Unbounded<T> result)
    {
        if (TryParseUnbounded(s, out result))
        {
            return true;
        }
        if (T.TryParse(s, provider, out var finite))
        {
            result = new(finite);
            return true;
        }
        result = null;
        return false;
    }

    public static bool TryParseUnbounded(string s, [NotNullWhen(true)] out Unbounded<T> result)
    {
        return TryParseUnbounded(s.AsSpan(), out result);
    }

    public static bool TryParseUnbounded(ReadOnlySpan<char> s, [NotNullWhen(true)] out Unbounded<T> result)
    {
        if (s.IsWhiteSpace() || MemoryExtensions.Equals(s, "None", StringComparison.OrdinalIgnoreCase))
        {
            result = Unbounded<T>.None;
            return true;
        }
        if (MemoryExtensions.Equals(s, "-Infinity", StringComparison.OrdinalIgnoreCase)
            || MemoryExtensions.Equals(s, "-∞", StringComparison.CurrentCulture))
        {
            result = Unbounded<T>.NegativeInfinity;
            return true;
        }
        if (MemoryExtensions.Equals(s, "Infinity", StringComparison.OrdinalIgnoreCase)
            || MemoryExtensions.Equals(s, "+Infinity", StringComparison.OrdinalIgnoreCase)
            || MemoryExtensions.Equals(s, "+∞", StringComparison.CurrentCulture)
            || MemoryExtensions.Equals(s, "∞", StringComparison.CurrentCulture))
        {
            result = Unbounded<T>.PositiveInfinity;
            return true;
        }
        result = null;
        return false;
    }
}
