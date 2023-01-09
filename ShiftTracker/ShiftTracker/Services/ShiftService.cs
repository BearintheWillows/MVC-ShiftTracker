namespace ShiftTracker.Services;

using Areas.Shifts.Models.DTO;
using Controllers;
using Data;
using Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public interface IShiftService : IBaseCrudService<Shift>
{
	Task<Shift>       GetAsync(int     id,            bool includeBreaks, bool includeRun, bool includeTimeData);
	Task<List<Shift>> GetAllAsync(bool includeBreaks, bool includeRun,    bool includeTimeData);
	Task<bool>        ExistsAsync(int? id);

	bool TimeEntryValidator(ShiftDto shiftDto);
}

public class ShiftService : BaseCrudService<Shift>, IShiftService
{
	private readonly ApplicationDbContext _context;
	
	public ShiftService(ApplicationDbContext context) : base(context)
	{
		_context = context;
	}
	
	public async Task<Shift?> GetAsync(int id, bool includeBreaks, bool includeRun, bool includeTimeData)
	{
		return await _context.Shifts
		                     .IncludeExtraShiftData( includeBreaks, includeRun, includeTimeData )
		                     .FirstOrDefaultAsync(s => s.Id == id);
	}
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="includeBreaks"></param>
	/// <param name="includeRun"></param>
	/// <param name="includeTimeData"></param>
	/// <returns></returns>
	public async Task<List<Shift>> GetAllAsync( bool includeBreaks = false, bool includeRun = false, bool includeTimeData = false)
	{
		return await _context.Shifts.AsQueryable().IncludeExtraShiftData( includeBreaks, includeRun, includeTimeData )
		                    .ToListAsync();
		
	}

	public async Task<bool> ExistsAsync(int? id)
	{
		return await _context.Shifts.AnyAsync(x => x.Id == id);
	}
	
	/// <summary>
	/// Checks if the shift times add up to the shift duration.
	/// </summary>
	/// <param name="shiftDto"></param>
	/// <returns>True/False</returns>
	public bool TimeEntryValidator(ShiftDto shiftDto)
	{
		return shiftDto.ShiftDuration.Equals( new TimeSpan(shiftDto.BreakDuration.Ticks + shiftDto.WorkTime.Ticks + shiftDto.OtherWorkTime.Ticks + shiftDto.DriveTime.Ticks) );
	}
}