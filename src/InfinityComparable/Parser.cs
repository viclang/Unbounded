using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public static partial class Infinity
    {
        private const string negativeInfinityString = "-Infinity";
        private const string positiveInfinityString = "Infinity";
        internal static string InfinityToString(bool positive) => positive ? positiveInfinityString : negativeInfinityString;

        [Pure]
        public static Infinity<T> Parse<T>(string value)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => Parse(value, s => (T)Convert.ChangeType(s, typeof(T)), Inf => Inf ? positiveInfinityString : negativeInfinityString);

        [Pure]
        public static Infinity<T> Parse<T>(string value, Func<string, T> finiteParser, Func<bool, string> infinityParser)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
        {
            if (string.IsNullOrEmpty(value) || value == infinityParser(true))
            {
                return Infinity<T>.PositiveInfinity;
            }
            else
            {
                return value == infinityParser(false)
                    ? Infinity<T>.NegativeInfinity
                    : finiteParser(value);
            }
        }

        [Pure]
        public static bool TryParse<T>(string value, out Infinity<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
            => TryParse(value, s => (T)Convert.ChangeType(s, typeof(T)), InfinityToString, out result);

        [Pure]
        public static bool TryParse<T>(string value, Func<string, T> finiteParser, Func<bool, string> infinityParser, out Infinity<T>? result)
            where T : struct, IEquatable<T>, IComparable<T>, IComparable
        {
            try
            {
                result = Parse(value, finiteParser, infinityParser);
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
