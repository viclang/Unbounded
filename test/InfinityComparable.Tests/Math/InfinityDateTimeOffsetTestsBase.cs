using UnboundedType.Tests.Factories;

namespace UnboundedType.Tests
{
    public abstract class InfinityDateTimeOffsetTestsBase
    {
        private static readonly DateTimeOffset _left = new DateTimeOffset(2023, 1, 2, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset _rightDateTime = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly double _rightDouble = 1;

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<TimeSpan>, Unbounded<DateTimeOffset>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _rightTimeSpan, _left + _rightTimeSpan);

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<double>, Unbounded<DateTimeOffset>> AddDaysData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddDays(_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<double>, Unbounded<DateTimeOffset>> AddHoursData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddHours(_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<double>, Unbounded<DateTimeOffset>> AddMillisecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMilliseconds(_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<double>, Unbounded<DateTimeOffset>> AddMinutesData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMinutes(_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<int>, Unbounded<DateTimeOffset>> AddMonthsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddMonths((int)_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<double>, Unbounded<DateTimeOffset>> AddSecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddSeconds(_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<long>, Unbounded<DateTimeOffset>> AddTicksData =
            InfinityMathDataFactory.CreateAddData(_left, (long)_rightDouble, _left.AddTicks((long)_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<int>, Unbounded<DateTimeOffset>> AddYearsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddYears((int)_rightDouble));

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<DateTimeOffset>, Unbounded<TimeSpan>> SubstractDateTimeData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightDateTime, _left - _rightDateTime);

        public static TheoryData<Unbounded<DateTimeOffset>, Unbounded<TimeSpan>, Unbounded<DateTimeOffset>> SubstractTimeSpanData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightTimeSpan, _left - _rightTimeSpan);
    }
}