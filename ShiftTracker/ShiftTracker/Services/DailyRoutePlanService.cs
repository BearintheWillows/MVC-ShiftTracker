namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;

public interface IDailyRoutePlanService : IBaseCrudService<DailyRoutePlan>
{
	
}

public class DailyRoutePlanService : BaseCrudService<DailyRoutePlan>, IDailyRoutePlanService
{
	private readonly ApplicationDbContext _context;

	public DailyRoutePlanService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
}