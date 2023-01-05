namespace ShiftTracker.Areas.Shifts.Models.DTO;

using ShiftTracker.Data.Models;

public class ShiftDto
{

	public int?      Id    { get; set; }
	public DateTime Date  { get; set; }
	public int      RunId { get; set; }
	public RunDto?   Run   { get; set; }
	// Navigation properties
	public List<BreakDto>? Breaks { get; set; }
	
	public TimeSpan StartTime     { get; set; }
	public TimeSpan EndTime       { get; set; }
	public TimeSpan BreakDuration { get; set; }
	public TimeSpan DriveTime     { get; set; }
	public TimeSpan ShiftDuration { get; set; }
	public TimeSpan OtherWorkTime { get; set; }
	public TimeSpan WorkTime      { get; set; }
	
	
}

