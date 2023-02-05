using System.Diagnostics.Contracts;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        internal const string NegativeInfinityString = "-Infinity";
        internal const string PositiveInfinityString = "Infinity";
        
        [Pure]
        public static Infinity<T> Parse<T>(string value)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => Parse(value, s => (T)Convert.ChangeType(s, typeof(T)));

        [Pure]
        public static Infinity<T> Parse<T>(string value, Func<string, T> finiteParser)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
        {
            if (string.IsNullOrEmpty(value) || value.Equals(PositiveInfinityString))
            {
                return Infinity<T>.PositiveInfinity;
            }
            else
            {
                return value.Equals(NegativeInfinityString)
                    ? Infinity<T>.NegativeInfinity
                    : finiteParser(value);
            }
        }

        [Pure]
        public static bool TryParse<T>(string value, out Infinity<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => TryParse(value, s => (T)Convert.ChangeType(s, typeof(T)), out result);

        [Pure]
        public static bool TryParse<T>(string value, Func<string, T> finiteParser, out Infinity<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
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

    }
}
