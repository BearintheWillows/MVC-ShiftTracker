namespace ShiftTracker.Areas.Shifts.Models.DTO;

public class ShiftWithTimeDataDto : BaseShiftDto
{
	public TimeSpan StartTime     { get; set; }
	public TimeSpan EndTime       { get; set; }
	public TimeSpan BreakDuration { get; set; }
	public TimeSpan DriveTime     { get; set; }
	public TimeSpan ShiftDuration { get; set; }
	public TimeSpan OtherWorkTime { get; set; }
	public TimeSpan WorkTime      { get; set; }
}