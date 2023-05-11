using System.Diagnostics.Contracts;

namespace Unbounded
{
    public static partial class Unbounded
    {
        public static Unbounded<T> Parse<T>(string value)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => Parse(value, s => (T)Convert.ChangeType(s, typeof(T)));

        public static Unbounded<T> Parse<T>(string value, Func<string, T> finiteParser)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
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

        public static bool TryParse<T>(string value, out Unbounded<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => TryParse(value, s => (T)Convert.ChangeType(s, typeof(T)), out result);

        public static bool TryParse<T>(string value, Func<string, T> finiteParser, out Unbounded<T>? result)
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
