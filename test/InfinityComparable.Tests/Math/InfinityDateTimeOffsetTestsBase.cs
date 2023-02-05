using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public abstract class InfinityDateTimeOffsetTestsBase
    {
        private static readonly DateTimeOffset _left = new DateTimeOffset(2023, 1, 2, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset _rightDateTime = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly double _rightDouble = 1;

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<TimeSpan>, Infinity<DateTimeOffset>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _rightTimeSpan, _left + _rightTimeSpan);

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<double>, Infinity<DateTimeOffset>> AddDaysData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddDays(_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<double>, Infinity<DateTimeOffset>> AddHoursData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddHours(_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<double>, Infinity<DateTimeOffset>> AddMillisecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMilliseconds(_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<double>, Infinity<DateTimeOffset>> AddMinutesData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMinutes(_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<int>, Infinity<DateTimeOffset>> AddMonthsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddMonths((int)_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<double>, Infinity<DateTimeOffset>> AddSecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddSeconds(_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<long>, Infinity<DateTimeOffset>> AddTicksData =
            InfinityMathDataFactory.CreateAddData(_left, (long)_rightDouble, _left.AddTicks((long)_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<int>, Infinity<DateTimeOffset>> AddYearsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddYears((int)_rightDouble));

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<DateTimeOffset>, Infinity<TimeSpan>> SubstractDateTimeData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightDateTime, _left - _rightDateTime);

        public static TheoryData<Infinity<DateTimeOffset>, Infinity<TimeSpan>, Infinity<DateTimeOffset>> SubstractTimeSpanData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightTimeSpan, _left - _rightTimeSpan);
    }
}