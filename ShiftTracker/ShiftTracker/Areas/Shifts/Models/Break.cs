namespace ShiftTracker.Areas.Shifts.Models;

public class Break
{
	
	public int Id { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public TimeSpan Duration { get; set; }
	
	// Navigation properties
	public int ShiftId { get; set; }
	public Shift Shift { get; set; }

}