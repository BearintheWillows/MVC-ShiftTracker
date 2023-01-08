namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;

public interface IRunService : IBaseCrudService<Run>
{
	
}

public class RunService : BaseCrudService<Run>, IRunService
{
	private readonly ApplicationDbContext _context;

	public RunService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
}