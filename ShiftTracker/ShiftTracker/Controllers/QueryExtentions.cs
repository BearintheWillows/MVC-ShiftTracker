namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public static class QueryExtentions
{
	public static IQueryable<Shift> IncludeExtraShiftData(
		this IQueryable<Shift> query,
		bool                   includeBreaks,
		bool                   includeRun,
		bool                   includeTimeData
	)
	{
		if ( includeBreaks ) query = query.Include( s => s.Breaks );

		if ( includeRun ) query = query.Include( s => s.Run );

		if ( includeTimeData && includeRun && includeBreaks )
			return query.Select( s => new Shift
					{
					Id = s.Id,
					Date = s.Date,
					RunId = s.RunId,
					StartTime = s.StartTime,
					EndTime = s.EndTime,
					ShiftDuration = s.ShiftDuration,
					BreakDuration = s.BreakDuration,
					OtherWorkTime = s.OtherWorkTime,
					WorkTime = s.WorkTime,
					Breaks = s.Breaks,
					Run = s.Run,
					}
			);
		else if ( !includeTimeData && includeRun && includeBreaks )
			return query.Select( s => new Shift
					{
					Id = s.Id,
					Date = s.Date,
					RunId = s.RunId,
					Breaks = s.Breaks,
					Run = s.Run,
					}
			);
		else if ( !includeTimeData && !includeRun && includeBreaks )
			return query.Select( s => new Shift
					{
					Id = s.Id, Date = s.Date, RunId = s.RunId, Breaks = s.Breaks,
					}
			);
		else if ( !includeTimeData && !includeBreaks && !includeRun )
			return query.Select( s => new Shift { Id = s.Id, Date = s.Date, RunId = s.RunId } );
		else if ( !includeTimeData && includeRun && !includeBreaks )
			return query.Select( s => new Shift { Id = s.Id, Date = s.Date, RunId = s.RunId, Run = s.Run } );
		else if ( includeTimeData && !includeRun && includeBreaks )
			return query.Select( s => new Shift
					{
					Id = s.Id,
					Date = s.Date,
					RunId = s.RunId,
					Breaks = s.Breaks,
					StartTime = s.StartTime,
					EndTime = s.EndTime,
					ShiftDuration = s.ShiftDuration,
					BreakDuration = s.BreakDuration,
					OtherWorkTime = s.OtherWorkTime,
					WorkTime = s.WorkTime,
					}
			);
		else if ( includeTimeData && includeRun && !includeBreaks )
			return query.Select( s => new Shift
					{
					Id = s.Id,
					Date = s.Date,
					RunId = s.RunId,
					Run = s.Run,
					StartTime = s.StartTime,
					EndTime = s.EndTime,
					ShiftDuration = s.ShiftDuration,
					BreakDuration = s.BreakDuration,
					OtherWorkTime = s.OtherWorkTime,
					WorkTime = s.WorkTime,
					}
			);

		return query;
	}
}