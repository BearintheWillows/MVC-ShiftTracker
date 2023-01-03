namespace ShiftTracker.Areas.Shifts.Models;

using Controllers;

public class ShiftDTO
{
	/// <summary>
	/// Create a new Shift entity with the specified parameters.
	/// </summary>
	/// <param name="runId"></param>
	/// <param name="date"></param>
	/// <param name="startTime"></param>
	/// <param name="endTime"></param>
	/// <param name="driveLength"></param>
	/// <param name="otherWork"></param>
	/// <param name="workTime"></param>
	public ShiftDTO(
		int      runId,
		DateTime date,
		DateTime startTime,
		DateTime endTime,
		TimeSpan driveLength,
		TimeSpan otherWork,
		TimeSpan workTime
	)
	{
		RunId = runId;
		Date = date;
		StartTime = startTime;
		EndTime = endTime;
		DriveTime = driveLength;
		OtherWorkTime = otherWork;
		WorkTime = workTime;
		ShiftDuration = GetShiftLength();
	}

	public int      Id            { get; set; }
	public DateTime Date          { get; set; }
	public int      RunId         { get; set; }
	public DateTime StartTime     { get; set; }
	public DateTime EndTime       { get; set; }
	public TimeSpan BreakDuration { get; set; }
	public TimeSpan DriveTime     { get; set; }
	public TimeSpan ShiftDuration { get; set; }

	public TimeSpan OtherWorkTime { get; set; }
	public TimeSpan WorkTime      { get; set; }

	// Navigation properties
	public ICollection<Break> Breaks { get; set; }

	public TimeSpan GetShiftLength()
	{
		return EndTime - StartTime;
	}
}