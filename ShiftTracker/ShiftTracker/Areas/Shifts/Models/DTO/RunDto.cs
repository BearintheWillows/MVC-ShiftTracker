namespace ShiftTracker.Areas.Shifts.Models.DTO;

using System.Collections;

public class RunDto
{
	public int? Id     { get; set; }
	public int  Number { get; set; }
	public TimeSpan StartTime { get; set; }
	
	public ICollection<ShiftDto>? BaseShifts { get; set; }
	public ICollection<DayVariantDto>     Shops              { get; set; }
}