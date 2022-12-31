using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable
{
    public enum InfinityState : byte
    {
        IsNaN = 0,
        IsFinite = 1,
        IsInfinity = 2,
    }
}
