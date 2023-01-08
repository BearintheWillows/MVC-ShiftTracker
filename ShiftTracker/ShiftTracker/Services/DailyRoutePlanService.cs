namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;

public interface IDailyRoutePlanService : IBaseCrudService<DailyRoutePlan>
{
	Task AddRangeAsync(List<DailyRoutePlan> dailyRoutes);
}

public class DailyRoutePlanService : BaseCrudService<DailyRoutePlan>, IDailyRoutePlanService
{
	private readonly ApplicationDbContext _context;

	public DailyRoutePlanService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}

	public async Task AddRangeAsync(List<DailyRoutePlan> dailyRoutes)
	{
		await _context.AddRangeAsync( dailyRoutes );
	}
}