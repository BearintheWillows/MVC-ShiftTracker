namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public interface IShiftService : IBaseCrudService<Shift>
{
	Task<bool> ExistsAsync(int id);
}

public class ShiftService : BaseCrudService<Shift>, IShiftService
{
	public readonly ApplicationDbContext _context;
	
	public ShiftService(ApplicationDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<bool> ExistsAsync(int id)
	{
		return await _context.Shifts.AnyAsync(x => x.Id == id);
	}
}