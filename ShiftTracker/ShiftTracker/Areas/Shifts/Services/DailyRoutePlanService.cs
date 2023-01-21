namespace ShiftTracker.Areas.Shifts.Services;

using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using ShiftTracker.Data;

public interface IDailyRoutePlanService : IBaseCrudService<DailyRoutePlan>
{
	Task<List<DailyRoutePlan>> GetRoutesForRunAsync(int         id);
	Task<List<DailyRoutePlan>> GetRouteForRunDayFilterAsync(int runId, DayOfWeek day);
	Task<bool>                 RunRouteExistsAsync(int          id);
}

public class DailyRoutePlanService : BaseCrudService<DailyRoutePlan>, IDailyRoutePlanService
{
	private readonly ApplicationDbContext _context;

	public DailyRoutePlanService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}

	//get all routes for a run
	public async Task<List<DailyRoutePlan>> GetRoutesForRunAsync(int id) =>
		await _context.DailyRoutes.Where( x => x.RunId == id ).ToListAsync();

	public async Task<List<DailyRoutePlan>> GetRouteForRunDayFilterAsync(int runId, DayOfWeek day) =>
		await _context.DailyRoutes.Where( dr => dr.RunId == runId && dr.DayOfWeek == day ).ToListAsync();


	public async Task<bool> RunRouteExistsAsync(int number) =>
		await _context.DailyRoutes.Include( dr => dr.Run ).AnyAsync( x => x.Run.Number == number );
}