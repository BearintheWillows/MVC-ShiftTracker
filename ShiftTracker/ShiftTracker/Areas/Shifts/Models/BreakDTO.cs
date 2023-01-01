namespace ShiftTracker.Controllers;

public class BreakDTO
{

	/// <summary>
	/// Create a new Break entity with the specified params.
	/// </summary>
	/// <param name="startTime"></param>
	/// <param name="endTime"></param>
	/// <param name="shiftId"></param>
	public BreakDTO(DateTime startTime, DateTime endTime, int shiftId)
	{
		ShiftId = shiftId;
		StartTime = startTime;
		EndTime = endTime;
		Duration = GetDuration();
	}
	
	public int      Id        { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime   { get; set; }
	public TimeSpan Duration  { get; set; }
	
	// Navigation properties
	public int   ShiftId { get; set; }
	public Shift Shift   { get; set; }

	private TimeSpan GetDuration()
	{
		return EndTime - StartTime;
	}
}