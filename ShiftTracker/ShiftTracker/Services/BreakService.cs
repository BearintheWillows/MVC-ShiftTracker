namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public interface IBreakService : IBaseCrudService<Break>
{
	Task<bool>               ExistsAsync(int?                      id);
	Task<IEnumerable<Break>> GetAllAsyncByShiftId(int              shiftId);
	Task<bool>               PostAllBreaksAsync(IEnumerable<Break> breaks);
}

public class BreakService : BaseCrudService<Break>, IBreakService
{
	private readonly ApplicationDbContext _context;

	public BreakService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
	
	public async Task<bool> PostAllBreaksAsync(IEnumerable<Break> breaks)
	{
		await _context.Breaks.AddRangeAsync(breaks);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> ExistsAsync(int? id) => await _context.Breaks.AnyAsync( s => s.Id == id );

	public async Task<IEnumerable<Break>> GetAllAsyncByShiftId(int shiftId) =>
		await _context.Breaks.Where( s => s.ShiftId == shiftId ).ToListAsync();
}