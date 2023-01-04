namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Areas.Shifts.Models;
using Data;

[ApiController, Route( "api/shifts" )]
public class ShiftsApiController : ControllerBase
{
	private readonly ApplicationDbContext _dbContext;

	public ShiftsApiController(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	/// <summary>
	/// Get all Shifts without Time Data/// 
	/// </summary>
	/// <param name="includeRun"></param>
	/// <param name="includeBreaks"></param>
	/// <returns>
	/// All Shift entities
	/// </returns>
	[HttpGet, Route( "base" )]
	public async Task<IActionResult> GetAllBaseShifts([FromQuery] bool includeRun = false, bool includeBreaks = false)
	{
		try
		{
			Task<List<Shift>> shiftResultAsync = Task.FromResult( await _dbContext.Shifts.AsQueryable()
				                                                     .IncludeBreaksCheck( includeBreaks )
				                                                     .InccludeRunCheck( includeRun )
				                                                     .ToListAsync()
			);
			while ( !shiftResultAsync.IsCompletedSuccessfully )
			{ }

			var shifts = shiftResultAsync.Result.Select( s => new BaseShiftDto
					{
					Id = s.Id,
					Date = s.Date,
					RunId = s.RunId,
					Breaks = includeBreaks
						? s.Breaks.Select( b => new BreakDto
								{
								Id = b.Id, ShiftId = b.ShiftId, StartTime = b.StartTime, EndTime = b.EndTime,
								}
						).ToList()
						: null,
					Run = includeRun ? new RunDto { Id = s.Run.Id, Number = s.Run.Number } : null,
					}
			).ToList();
			return Ok( shifts );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest();
		}
	}

	/// <summary>
	/// Get Shift by Id
	/// </summary>
	/// <param name="id"></param>
	/// <param name="includeRun"></param>
	/// <param name="includeBreaks"></param>
	/// <returns></returns>
	[HttpGet, Route( "base/{id}" )]
	public async Task<BaseShiftDto> GetBaseShiftById(int id, bool includeRun = false, bool includeBreaks = false)
	{
		try
		{
			Task<Shift?> shiftResultAsync =  Task.FromResult( await _dbContext.Shifts.AsQueryable()
			                                                                  .IncludeBreaksCheck( includeBreaks )
			                                                                  .InccludeRunCheck( includeRun )
			                                                                  .FirstOrDefaultAsync( s => s.Id == id )
			);
			while ( !shiftResultAsync.IsCompletedSuccessfully )
			{ }

			var shift = shiftResultAsync.Result;
			if ( shift == null )
			{
				return null;
			}
			
			var baseShift = new BaseShiftDto
					{
					Id = shift.Id,
					Date = shift.Date,
					RunId = shift.RunId,
					Breaks = includeBreaks
						? shift.Breaks.Select( b => new BreakDto
								{
								Id = b.Id, ShiftId = b.ShiftId, StartTime = b.StartTime, EndTime = b.EndTime,
								}
						).ToList()
						: null,
					Run = includeRun ? new RunDto { Id = shift.Run.Id, Number = shift.Run.Number } : null,
					};
			return baseShift;
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shift" );
			Console.WriteLine( e );
			return null;
		}
	}
	
	/// <summary>
	/// Creates a new shift.
	/// ShiftWithTimeDataDto is used to create a new shift with time data.
	/// </summary>
	/// <param name="shiftDto"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult?> CreateShift([FromBody] ShiftWithTimeDataDto shiftDto)
	{
		try
		{
			var shift = new Shift
					{
					Date = shiftDto.Date,
					RunId = shiftDto.RunId,
					Breaks = new List<Break>(),
					StartTime = shiftDto.StartTime,
					EndTime = shiftDto.EndTime,
					BreakDuration = shiftDto.BreakDuration,
					DriveTime = shiftDto.DriveTime,
					ShiftDuration = shiftDto.ShiftDuration,
					OtherWorkTime = shiftDto.OtherWorkTime,
					WorkTime = shiftDto.WorkTime,
					};
			if ( !TimeEntryValidation( shift ) )
			{
				return BadRequest("Time entries do not add up to shift duration") ;
			}
			await _dbContext.Shifts.AddAsync( shift );
			await _dbContext.SaveChangesAsync();
			shiftDto.Id = shift.Id;
			return Ok(shiftDto);
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error creating shift" );
			Console.WriteLine( e );
			return BadRequest(null);
		}
	}
	
	/// <summary>
	/// Checks if the shift times add up to the shift duration.
	/// </summary>
	/// <param name="shiftDto"></param>
	/// <returns>True/False</returns>
	private static bool TimeEntryValidation(Shift shiftDto)
	{
		Console.WriteLine(shiftDto.ShiftDuration);
		Console.WriteLine(shiftDto.DriveTime + shiftDto.BreakDuration + shiftDto.OtherWorkTime + shiftDto.WorkTime);
		Console.WriteLine(shiftDto.ShiftDuration.Equals(shiftDto.BreakDuration + shiftDto.WorkTime + shiftDto.OtherWorkTime + shiftDto.DriveTime));
		return shiftDto.ShiftDuration.Equals( new TimeSpan(shiftDto.BreakDuration.Ticks + shiftDto.WorkTime.Ticks + shiftDto.OtherWorkTime.Ticks + shiftDto.DriveTime.Ticks) );
	}
}