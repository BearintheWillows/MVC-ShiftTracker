namespace ShiftTracker.Areas.Shifts.Models;

public class Shift
{
	
	public int      Id               { get; set; }
	public DateTime Date             { get; set; }
	public int      RunId            { get; set; }
	public DateTime StartTime        { get; set; }
	public DateTime EndTime          { get; set; }
	public TimeSpan TotalBreakLength { get; set; }
	public TimeSpan TotalDriveLength { get; set; }
	public TimeSpan TotalShiftLength { get; set; } 
	
	public TimeSpan TotalOtherWorkLength  { get; set; }
	public TimeSpan TotalWorkLength  { get; set; }
	
	// Navigation properties
	public ICollection<Break>? Breaks { get; set; }
}