﻿namespace ShiftTracker.Areas.Shifts.Models.DTO;

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
	
}