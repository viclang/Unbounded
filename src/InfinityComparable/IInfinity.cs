namespace InfinityComparable
{
    internal interface IInfinity<T>
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        T? Finite { get; }

        bool IsNaN { get; }

        bool IsFinite { get; }

        bool IsInfinity { get; }

        T GetValueOrDefault();

        T GetValueOrDefault(T other);

        bool IsPositiveInfinity();

        bool IsNegativeInfinity();
    }
}
