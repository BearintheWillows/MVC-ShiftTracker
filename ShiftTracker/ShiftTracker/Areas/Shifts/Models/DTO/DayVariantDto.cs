﻿namespace ShiftTracker.Areas.Shifts.Models.DTO;

using Data.Models;

public class DayVariantDto
{
	public int?      Id        { get; set; }
	public DayOfWeek DayOfWeek { get; set; }

	//Delivery Window Start/End Times
	public TimeSpan? WindowOpenTime  { get; set; }
	public TimeSpan? WindowCloseTime { get; set; }

	public int?    RunId { get; set; }
	public RunDto? Run   { get; set; }

	public int      ShopId { get; set; }
	public ShopDto? Shop   { get; set; }

	public static ICollection<DayVariant> CreateVariants(int runId)
	{
		var variants = new List<DayVariant>();
		for ( var i = 0; i < 7; i++ )
		{
			variants.Add( new DayVariant
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