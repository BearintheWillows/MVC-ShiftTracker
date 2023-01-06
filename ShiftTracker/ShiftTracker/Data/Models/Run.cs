namespace ShiftTracker.Data.Models;

using Areas.Shifts.Models;

public class Run
{
	public int      Id        { get; set; }
	public int      Number    { get; set; }
	public TimeSpan StartTime { get; set; }
	
	public ICollection<Shift> Shifts { get; set; }
	public ICollection<DayVariant> Shops { get; set; }
}