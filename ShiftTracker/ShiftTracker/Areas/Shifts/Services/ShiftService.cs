namespace ShiftTracker.Areas.Shifts.Services;

using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Models.DTO;

using Extentions;
using ShiftTracker.Data;

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
	private readonly IBreakService        _breakService;

	public ShiftService(ApplicationDbContext context, IBreakService breakService) : base( context )
	{
		_context = context;
		_breakService = breakService;
	}

	public async Task<Shift?> GetAsync(int id, bool includeBreaks, bool includeRun, bool includeTimeData) =>
		await _context.Shifts
		              .IncludeExtraShiftData( includeBreaks, includeRun, includeTimeData )
		              .FirstOrDefaultAsync( s => s.Id == id );

	/// <summary>
	/// </summary>
	/// <param name="includeBreaks"></param>
	/// <param name="includeRun"></param>
	/// <param name="includeTimeData"></param>
	/// <returns></returns>
	public async Task<List<Shift>> GetAllAsync(
		bool includeBreaks   = false,
		bool includeRun      = false,
		bool includeTimeData = false
	) => await _context.Shifts.AsQueryable().IncludeExtraShiftData( includeBreaks, includeRun, includeTimeData )
	                   .ToListAsync();

	public async Task<bool> ExistsAsync(int? id) => await _context.Shifts.AnyAsync( x => x.Id == id );

	/// <summary>
	///     Checks if the shift times add up to the shift duration.
	/// </summary>
	/// <param name="shiftDto"></param>
	/// <returns>True/False</returns>
	public bool TimeEntryValidator(ShiftDto shiftDto) => shiftDto.ShiftDuration.Equals(
		new TimeSpan( shiftDto.BreakDuration.Ticks + shiftDto.WorkTime.Ticks + shiftDto.OtherWorkTime.Ticks +
		              shiftDto.DriveTime.Ticks
		)
	);
	
}