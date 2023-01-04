namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public static class QueryExtentions
{
	public static IQueryable<Shift> IncludeBreaksCheck(this IQueryable<Shift> query, bool includeBreaks)
	{
		return includeBreaks ? query.Include(s => s.Breaks) : query;
	}


	public static IQueryable<Shift> InccludeRunCheck(this IQueryable<Shift> query, bool includeRun)
	{
		return includeRun ? query.Include(s => s.Run) : query;
	}
}