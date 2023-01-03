namespace ShiftTracker.Areas.Shifts.Models.DTO;

using ShiftTracker.Data.Models;

public class BaseShiftDto
{

	public int?      Id            { get; set; }
	public DateTime? Date          { get; set; }
	public int?      RunId         { get; set; }

	// Navigation properties
	public ICollection<Break> Breaks { get; set; }
	
}