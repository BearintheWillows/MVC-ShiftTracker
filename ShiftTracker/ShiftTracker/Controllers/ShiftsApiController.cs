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

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		
		try
		{
			Shift shift = await _dbContext.Shifts.FirstOrDefaultAsync( s => s.Id == id );
			var shiftDto = new ShiftDTO()
			{
				Id = shift.Id,
				RunId = shift.RunId,
				Date = shift.Date,
				StartTime = shift.StartTime,
				EndTime = shift.EndTime,
				TotalBreakLength =  shift.TotalBreakLength,
				TotalDriveLength = shift.TotalDriveLength,
				TotalShiftLength = shift.TotalShiftLength,
				TotalOtherWorkLength = shift.TotalOtherWorkLength,
				TotalWorkLength = shift.TotalWorkLength,
				Breaks = shift.Breaks,
			};
			return Ok( shiftDto );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shift" );
			return BadRequest( null );
		}
	}
}
