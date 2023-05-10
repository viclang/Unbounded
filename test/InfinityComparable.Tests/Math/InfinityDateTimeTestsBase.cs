using UnboundedType.Tests.Factories;

namespace UnboundedType.Tests
{
    public abstract class InfinityDateTimeTestsBase
    {
        private static readonly DateTime _left = new DateTime(2023, 1, 2);
        private static readonly DateTime _rightDateTime = new DateTime(2023, 1, 1);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly double _rightDouble = 1;

        public static TheoryData<Unbounded<DateTime>, Unbounded<TimeSpan>, Unbounded<DateTime>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _rightTimeSpan, _left + _rightTimeSpan);

        public static TheoryData<Unbounded<DateTime>, Unbounded<double>, Unbounded<DateTime>> AddDaysData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddDays(_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<double>, Unbounded<DateTime>> AddHoursData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddHours(_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<double>, Unbounded<DateTime>> AddMillisecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMilliseconds(_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<double>, Unbounded<DateTime>> AddMinutesData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMinutes(_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<int>, Unbounded<DateTime>> AddMonthsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddMonths((int)_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<double>, Unbounded<DateTime>> AddSecondsData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddSeconds(_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<long>, Unbounded<DateTime>> AddTicksData =
            InfinityMathDataFactory.CreateAddData(_left, (long)_rightDouble, _left.AddTicks((long)_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<int>, Unbounded<DateTime>> AddYearsData =
            InfinityMathDataFactory.CreateAddData(_left, (int)_rightDouble, _left.AddYears((int)_rightDouble));

        public static TheoryData<Unbounded<DateTime>, Unbounded<DateTime>, Unbounded<TimeSpan>> SubstractDateTimeData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightDateTime, _left - _rightDateTime);

        public static TheoryData<Unbounded<DateTime>, Unbounded<TimeSpan>, Unbounded<DateTime>> SubstractTimeSpanData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightTimeSpan, _left - _rightTimeSpan);
    }
}