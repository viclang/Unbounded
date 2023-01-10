using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public abstract class InfinityDateTimeTestsBase
    {
        private static readonly DateTime _left = new DateTime(2023, 1, 2);
        private static readonly DateTime _rightDateTime = new DateTime(2023, 1, 1);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly double _rightDouble = 1;

        protected static TheoryData<Infinity<DateTime>, Infinity<TimeSpan>, Infinity<DateTime>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _rightTimeSpan, _left + _rightTimeSpan);

        protected static TheoryData<Infinity<DateTime>, Infinity<double>, Infinity<DateTime>> AddDaysData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddDays(_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<double>, Infinity<DateTime>> AddHoursData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddHours(_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<double>, Infinity<DateTime>> AddMillisecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMilliseconds(_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<double>, Infinity<DateTime>> AddMinutesData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMinutes(_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<int>, Infinity<DateTime>> AddMonthsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddMonths((int)_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<double>, Infinity<DateTime>> AddSecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddSeconds(_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<long>, Infinity<DateTime>> AddTicksData =
            InfinityMathDataFactory.CreateAddData(_left, (long)_rightDouble, _left.AddTicks((long)_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<int>, Infinity<DateTime>> AddYearsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddYears((int)_rightDouble));

        protected static TheoryData<Infinity<DateTime>, Infinity<DateTime>, Infinity<TimeSpan>> SubstractDateTimeData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightDateTime, _left - _rightDateTime);

        protected static TheoryData<Infinity<DateTime>, Infinity<TimeSpan>, Infinity<DateTime>> SubstractTimeSpanData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightTimeSpan, _left - _rightTimeSpan);
    }
}