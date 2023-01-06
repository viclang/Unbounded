using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityComparable.Tests.Calculator
{
    public abstract class CalculatorTestBase
    {

        public static TheoryData<Infinity<float>, Infinity<float>, Infinity<float>> Float_Data =
            new CalculatorDataBuilder<float, float, float>(1, 2, 3).Build();

        public static TheoryData<Infinity<double>, Infinity<double>, Infinity<double>> Double_Data =
            new CalculatorDataBuilder<double, double, double>(1, 2, 3).Build();

        public static TheoryData<Infinity<decimal>, Infinity<decimal>, Infinity<decimal>> Decimal_Data =
            new CalculatorDataBuilder<decimal, decimal, decimal>(1, 2, 3).Build();

        public static TheoryData<Infinity<TimeSpan>, Infinity<TimeSpan>, Infinity<TimeSpan>> TimeSpan_Data =
            new CalculatorDataBuilder<TimeSpan, TimeSpan, TimeSpan>(TimeSpan.FromHours(1), TimeSpan.FromHours(2), TimeSpan.FromHours(3)).Build();

        public static TheoryData<Infinity<DateTime>, Infinity<TimeSpan>, Infinity<DateTime>> DateTime_Data =
            new CalculatorDataBuilder<DateTime, TimeSpan, DateTime>(
                new DateTime(2023, 1, 1),
                TimeSpan.FromDays(1),
                new DateTime(2023, 1, 2)).Build();

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<TimeSpan>, Infinity<DateTimeOffset>> DateTimeOffset_Data =
            new CalculatorDataBuilder<DateTimeOffset, TimeSpan, DateTimeOffset>(
                new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero),
                TimeSpan.FromDays(1),
                new DateTimeOffset(2023, 1, 2, 0, 0, 0, TimeSpan.Zero)).Build();

        public static TheoryData<Infinity<DateOnly>, Infinity<int>, Infinity<DateOnly>> DateOnly_Data =
            new CalculatorDataBuilder<DateOnly, int, DateOnly>(
                new DateOnly(2023, 1, 1),
                1,
                new DateOnly(2023, 1, 2)).Build();
    }
}
