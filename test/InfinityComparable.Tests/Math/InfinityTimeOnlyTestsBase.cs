using InfinityComparable.Tests.Factories;

namespace InfinityComparable.Tests
{
    public class InfinityTimeOnlyTestsBase
    {
        private static readonly TimeOnly _left = new TimeOnly(2, 0, 0);
        private static readonly TimeOnly _rightTimeOnly = new TimeOnly(1, 0, 0);
        private static readonly TimeSpan _rightTimeSpan = TimeSpan.FromDays(1);
        private static readonly double _rightDouble = 1;

        public static TheoryData<Infinity<TimeOnly>, Infinity<TimeSpan>, Infinity<TimeOnly>> AddData =
            InfinityMathDataFactory.CreateAddData(_left, _rightTimeSpan, _left.Add(_rightTimeSpan));

        public static TheoryData<Infinity<TimeOnly>, Infinity<double>, Infinity<TimeOnly>> AddHoursData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddHours(_rightDouble));

        public static TheoryData<Infinity<TimeOnly>, Infinity<double>, Infinity<TimeOnly>> AddMinutesData =
            InfinityMathDataFactory.CreateAddData(_left, _rightDouble, _left.AddMinutes(_rightDouble));

        public static TheoryData<Infinity<TimeOnly>, Infinity<TimeOnly>, Infinity<TimeSpan>> SubstractTimeOnlyData =
            InfinityMathDataFactory.CreateSubstractData(_left, _rightTimeOnly, _left - _rightTimeOnly);
    }
}