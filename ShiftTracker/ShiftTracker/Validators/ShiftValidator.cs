namespace ShiftTracker.Pages.Validators;

using Data.Models;
using ShiftTracker.Areas.Shifts.Models.DTO;

public static class ShiftValidator
{
	/// <summary>
	/// Checks if the shift times add up to the shift duration.
	/// </summary>
	/// <param name="shiftDto"></param>
	/// <returns>True/False</returns>
	public static bool TimeEntryValidation(ShiftDto shiftDto)
	{
		return shiftDto.ShiftDuration.Equals( new TimeSpan(shiftDto.BreakDuration.Ticks + shiftDto.WorkTime.Ticks + shiftDto.OtherWorkTime.Ticks + shiftDto.DriveTime.Ticks) );
	}
}