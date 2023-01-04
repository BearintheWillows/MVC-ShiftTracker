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
	/// Base call returns Shifts without Breaks or Run Data
	/// includeRun = True additionally returns Run Data
	/// includeBreak = True additionally returns Break Data
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
}