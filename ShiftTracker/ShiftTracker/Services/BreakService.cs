namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public interface IBreakService : IBaseCrudService<Break>
{
	Task<bool>               ExistsAsync(int?         id);
	Task<IEnumerable<Break>> GetAllAsyncByShiftId(int shiftId);
}

public class BreakService : BaseCrudService<Break>, IBreakService
{
	private readonly ApplicationDbContext _context;

	public BreakService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
	
	public async Task<bool> ExistsAsync(int? id)
	{
		return await _context.Breaks.AnyAsync( s => s.Id == id);
	}
	
	public async Task<IEnumerable<Break>> GetAllAsyncByShiftId(int shiftId)
	{
		return await _context.Breaks.Where( s => s.ShiftId == shiftId).ToListAsync();
	}
}