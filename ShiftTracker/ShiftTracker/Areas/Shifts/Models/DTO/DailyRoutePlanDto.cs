namespace ShiftTracker.Areas.Shifts.Models.DTO;

using Data.Models;

public class DailyRoutePlanDto
{
	public int?      Id        { get; set; }
	public DayOfWeek DayOfWeek { get; set; }

	//Delivery Window Start/End Times
	public TimeSpan? WindowOpenTime  { get; set; }
	public TimeSpan? WindowCloseTime { get; set; }

	public int?    RunId { get; set; }
	public RunDto? Run   { get; set; }

	public int                  ShopId { get; set; }
	public IEnumerable<ShopDto> Shop   { get; set; }

	public static ICollection<DailyRoutePlan> CreateVariants(int runId)
	{
		var variants = new List<DailyRoutePlan>();
		for ( var i = 0; i < 7; i++ )
		{
			variants.Add( new DailyRoutePlan
					{
					DayOfWeek = ( DayOfWeek ) i,
					WindowOpenTime = new TimeSpan( 0, 0, 0 ),
					WindowCloseTime = new TimeSpan( 0, 0, 0 ),
					RunId = runId,
					}
			);
			
		}
		return variants;
	}
}