using System;

namespace laba_tru.sodikov
{
    public class RunningRecord
    {
        public DateTime RunDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public double DistanceKm { get; set; }
        public double MaxSpeedKmh { get; set; }
        public double MinSpeedKmh { get; set; }
        public double AvgSpeedKmh { get; set; }
        public int AvgPulseBpm { get; set; }

        public bool IsWeekend => RunDate.DayOfWeek == DayOfWeek.Saturday ||
                               RunDate.DayOfWeek == DayOfWeek.Sunday;
    }
}