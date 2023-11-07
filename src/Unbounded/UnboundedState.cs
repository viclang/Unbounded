namespace Unbounded;

public enum UnboundedState : byte
{
    None = 0,
    NegativeInfinity = 1,
    Finite = 2,
    PositiveInfinity = 3,
}
