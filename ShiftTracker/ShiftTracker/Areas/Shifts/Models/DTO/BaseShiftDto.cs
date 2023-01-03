namespace ShiftTracker.Areas.Shifts.Models.DTO;

using ShiftTracker.Data.Models;

public class BaseShiftDto
{

	public int?      Id            { get; set; }
	public DateTime? Date          { get; set; }
	public int?      RunId         { get; set; }
	public RunDto Run { get; set; }
	// Navigation properties
	public ICollection<BreakDto> Breaks { get; set; }
	
}