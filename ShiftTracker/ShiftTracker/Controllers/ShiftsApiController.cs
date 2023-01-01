namespace ShiftTracker.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShiftTracker.Areas.Shifts.Models;
using ShiftTracker.Data;

[ApiController]
[Route("api/shifts")]
public class ShiftsApiController : ControllerBase
{
	private readonly ApplicationDbContext _dbContext;

	public ShiftsApiController(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var shifts = new List<Shift>();
		try
		{
			shifts = await _dbContext.Shifts.ToListAsync();
			return Ok(shifts);
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest( shifts );
		}
	}

	// [HttpGet("{id}")]
	// public async Task<IActionResult> GetShiftByIdWithBreaks(int id)
	// {
	// 	
	// 	try
	// 	{
	// 		ShiftDTO? shift = await _dbContext.Shifts.Where( s => s.Id == id ).Include( s => s.Breaks ).Select(  shift => new ShiftDTO()
	// 			{
	// 			Id = shift.Id,
	// 			RunId = shift.RunId,
	// 			Date = shift.Date,
	// 			StartTime = shift.StartTime,
	// 			EndTime = shift.EndTime,
	// 			TotalBreakLength =  shift.TotalBreakLength,
	// 			TotalDriveLength = shift.TotalDriveLength,
	// 			TotalOtherWorkLength = shift.TotalOtherWorkLength,
	// 			TotalShiftLength = shift.EndTime - shift.StartTime,
	// 			TotalWorkLength = shift.TotalShiftLength - shift.TotalBreakLength - shift.TotalDriveLength - shift.TotalOtherWorkLength,
	// 			Breaks = shift.Breaks.Where( b=> b.Id == shift.Id ).Select( b => new BreakDTO()
	// 			{
	// 				Id = b.Id,
	// 			StartTime = b.StartTime,
	// 				EndTime = b.EndTime,
	// 			} ).ToList().OrderBy( b => b.StartTime ) ,
	// 			} ).FirstOrDefaultAsync();
	// 		return Ok( shift );
	// 	}
	// 	catch ( Exception e )
	// 	{
	// 		Log.Error( e, "Error getting shift" );
	// 		return BadRequest( null );
	// 	}
	// }

}
