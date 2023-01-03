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
		var shifts = new List<BaseShiftDto>();
		try
		{
			if ( includeRun == false && includeBreaks == false )
				shifts = await _dbContext.Shifts
				                         .Select( s => new BaseShiftDto { Id = s.Id, Date = s.Date, RunId = s.RunId } )
				                         .ToListAsync();
			else if ( includeRun == true && includeBreaks == false )
				shifts = await _dbContext.Shifts
				                         .Include( s => s.Run )
				                         .Select( s => new BaseShiftDto
						                          {
						                          Id = s.Id,
						                          Date = s.Date,
						                          RunId = s.RunId,
						                          Run = new RunDto
							                          {
							                          Id = s.Run.Id, Number = s.Run.Number, StartTime = s.Run.StartTime,
							                          },
						                          }
				                          ).ToListAsync();
			else if ( includeRun == false && includeBreaks == true )
				shifts = await _dbContext.Shifts
				                         .Include( s => s.Breaks )
				                         .Select( s => new BaseShiftDto
						                          {
						                          Id = s.Id,
						                          Date = s.Date,
						                          RunId = s.RunId,
						                          Breaks = s.Breaks.Select( b => new BreakDto
								                          {
								                          Id = b.Id,
								                          StartTime = b.StartTime,
								                          EndTime = b.EndTime,
								                          Duration = s.EndTime - s.StartTime,
								                          }
						                          ).ToList(),
						                          }
				                          )
				                         .ToListAsync();
			else
				shifts = await _dbContext.Shifts
				                         .Include( s => s.Run )
				                         .Include( s => s.Breaks )
				                         .Select( s => new BaseShiftDto
						                          {
						                          Id = s.Id,
						                          Date = s.Date,
						                          RunId = s.RunId,
						                          Run = new RunDto
							                          {
							                          Id = s.Run.Id, Number = s.Run.Number, StartTime = s.Run.StartTime,
							                          },
						                          Breaks = s.Breaks.Select( b => new BreakDto
								                          {
								                          Id = b.Id,
								                          StartTime = b.StartTime,
								                          EndTime = b.EndTime,
								                          Duration = s.EndTime - s.StartTime,
								                          }
						                          ).ToList(),
						                          }
				                          ).ToListAsync();
			return Ok( shifts );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest( shifts );
		}
	}
}