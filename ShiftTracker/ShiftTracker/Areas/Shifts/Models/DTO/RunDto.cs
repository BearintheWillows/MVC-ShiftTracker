namespace ShiftTracker.Areas.Shifts.Models.DTO;

using System.Collections;

public class RunDto
{
	public int? Id     { get; set; }
	public int  Number { get; set; }
	public TimeSpan StartTime { get; set; }
	
	public ICollection<BaseShiftDto>?         BaseShifts         { get; set; }
	public ICollection<ShiftWithTimeDataDto>? ShiftsWithTimeData { get; set; }
	public ICollection<ShopDayVariantDto>     Shops              { get; set; }
}