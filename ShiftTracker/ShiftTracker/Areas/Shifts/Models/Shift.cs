namespace ShiftTracker.Areas.Shifts.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalHours { get; set; } = TimeSpan.Zero;
        public TimeSpan TotalDrivingTime { get; set; } = TimeSpan.Zero;
        public TimeSpan TotalBreakTime { get; set; } = TimeSpan.Zero;
        public TimeSpan TotalWorkTime { get; set; } = TimeSpan.Zero;
        public TimeSpan TotalOtherWorkTime { get; set; } = TimeSpan.Zero;

        public UserId { get; set; }
    public ICollection<Break> Breaks { get; set; }

}
}