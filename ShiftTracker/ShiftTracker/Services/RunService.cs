namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public interface IRunService : IBaseCrudService<Run>
{
	Task<List<Run>> GetAllAsync(bool includeDRP);
}

public class RunService : BaseCrudService<Run>, IRunService
{
	private readonly ApplicationDbContext _context;

	public RunService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
	
	public async Task<List<Run>> GetAllAsync(bool includeDRP)
	{
		if ( includeDRP )
		{
			return await _context.Runs.Include( r => r.RoutePlans ).ThenInclude(r => r.Shop).ToListAsync();
		} else
		{
			return await _context.Runs.ToListAsync();
		}
	}
}