// namespace ShiftTracker.Controllers;
//
// using System.Runtime.InteropServices.JavaScript;
// using Areas.Shifts.Models.DTO;
// using Data.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Serilog;
// using Areas.Shifts.Models;
// using Data;
// using Pages.Validators;
// using Microsoft.AspNetCore.Http.HttpResults;
//
// [ApiController, Route( "api/shifts" )]
// public class ShiftsApiController : ControllerBase
// {
// 	private static ApplicationDbContext _dbContext;
//
// 	public ShiftsApiController(ApplicationDbContext dbContext)
// 	{
// 		_dbContext = dbContext;
// 	}
//
// 	/// <summary>
// 	/// Get all Shifts without Time Data/// 
// 	/// </summary>
// 	/// <param name="includeRun"></param>
// 	/// <param name="includeBreaks"></param>
// 	/// <returns>
// 	/// All Shift entities
// 	/// </returns>
// 	[HttpGet]
// 	public async Task<IActionResult> GetAllShifts(
// 		[FromQuery] bool includeRun      = false,
// 		bool             includeBreaks   = false,
// 		bool             includeTimeData = false
// 	)
// 	{
// 		try
// 		{
// 			List<Shift> shiftResultAsync = _dbContext.Shifts.AsQueryable()
// 			                                               .IncludeExtraShiftData( includeBreaks,
// 			                                                                  includeRun,
// 			                                                                  includeTimeData
// 			                                                )
// 			                                               .ToList();
// 			var shifts = shiftResultAsync.Select( s => new 
// 					{
// 					 _ = ShiftDto.CreateDto(s, (includeBreaks, includeRun,  includeTimeData))
// 					}
// 			).ToList();
// 			return Ok( shifts );
// 		}
// 		catch ( Exception e )
// 		{
// 			Log.Error( e, "Error getting shifts" );
// 			Console.WriteLine( e );
// 			return BadRequest();
// 		}
// 	}
//
// 	/// <summary>
// 	/// Get Shift by Id
// 	/// </summary>
// 	/// <param name="id"></param>
// 	/// <param name="includeRun"></param>
// 	/// <param name="includeBreaks"></param>
// 	/// <param name="includeTimeData"></param>
// 	/// <returns></returns>
// 	[HttpGet( "{id}" )]
// 	public async Task<ActionResult<ShiftDto?>> GetShiftById(int id, [FromQuery] bool includeRun = false, bool includeBreaks = false, bool includeTimeData = false)
// 	{
// 		try
// 		{
// 			var shift = _dbContext.Shifts.AsQueryable()
// 			                            .IncludeExtraShiftData( includeBreaks, includeRun, includeTimeData )
// 			                            .FirstOrDefault( s => s.Id == id );
// 			if (shift != null)
// 				return await ShiftDto.CreateDto(shift, (includeBreaks, includeRun, includeTimeData));
//
// 			return BadRequest("Shift not found");
// 		}
// 		catch ( Exception e )
// 		{
// 			Log.Error( e, "Error getting shift" );
// 			Console.WriteLine( e );
// 			return BadRequest("Error getting shift");
// 		}
// 	}
// 	
//
// 	/// <summary>
// 	/// Creates a new shift.
// 	/// ShiftWithTimeDataDto is used to create a new shift with time data.
// 	/// </summary>
// 	/// <param name="shiftDto"></param>
// 	/// <returns></returns>
// 	[HttpPost]
// 	public async Task<ActionResult?> AddShift([FromBody] ShiftDto shiftDto)
// 	{
// 		if ( !ShiftValidator.TimeEntryValidation( shiftDto ) )
// 		{
// 			return BadRequest("Time entries do not add up to shift duration total") ;
// 		}
// 		
// 		try
// 		{
// 			var shift = new Shift
// 					{
// 					Date = shiftDto.Date,
// 					RunId = shiftDto.RunId,
// 					Breaks = new List<Break>(),
// 					StartTime = shiftDto.StartTime,
// 					EndTime = shiftDto.EndTime,
// 					BreakDuration = shiftDto.BreakDuration,
// 					DriveTime = shiftDto.DriveTime,
// 					ShiftDuration = shiftDto.ShiftDuration,
// 					OtherWorkTime = shiftDto.OtherWorkTime,
// 					WorkTime = shiftDto.WorkTime,
// 					};
// 			await _dbContext.Shifts.AddAsync( shift );
// 			await _dbContext.SaveChangesAsync();
// 			shiftDto.Id = shift.Id;
// 			return Ok(shiftDto);
// 		}
// 		catch ( Exception e )
// 		{
// 			Log.Error( e, "Error creating shift" );
// 			Console.WriteLine( e );
// 			return BadRequest(null);
// 		}
// 	}
// 	
// 	[HttpDelete("delete/{id}")]
// 	public async Task<ActionResult> DeleteShift(int id)
// 	{
// 		try
// 		{
// 			var shift = await _dbContext.Shifts.FindAsync( id );
// 			if (shift == null)
// 				return NotFound("Shift not found");
// 			_dbContext.Shifts.Remove( shift );
// 			await _dbContext.SaveChangesAsync();
// 			return Ok("Shift Deleted Successfully");
// 		}
// 		catch ( Exception e )
// 		{
// 			Log.Error( e, "Error deleting shift" );
// 			Console.WriteLine( e );
// 			return BadRequest("Error deleting shift");
// 		}
// 	}
// 	
// 	[HttpPut]
// 	public async Task<IActionResult> UpdateShift([FromBody] ShiftDto shiftDto)
// 	{
// 		if ( !ShiftValidator.TimeEntryValidation( shiftDto ) )
// 		{
// 			return BadRequest("Time entries do not add up to shift duration total") ;
// 		}
// 		
// 		try
// 		{
// 			var shift = await _dbContext.Shifts.FindAsync( shiftDto.Id );
// 			if (shift == null)
// 				return NotFound("Shift not found");
// 			shift.Date = shiftDto.Date;
// 			shift.RunId = shiftDto.RunId;
// 			shift.StartTime = shiftDto.StartTime;
// 			shift.EndTime = shiftDto.EndTime;
// 			shift.BreakDuration = shiftDto.BreakDuration;
// 			shift.DriveTime = shiftDto.DriveTime;
// 			shift.ShiftDuration = shiftDto.ShiftDuration;
// 			shift.OtherWorkTime = shiftDto.OtherWorkTime;
// 			shift.WorkTime = shiftDto.WorkTime;
// 			_dbContext.Shifts.Update( shift );
// 			await _dbContext.SaveChangesAsync();
// 			return Ok("Shift Updated Successfully");
// 		}
// 		catch ( Exception e )
// 		{
// 			Log.Error( e, "Error updating shift" );
// 			Console.WriteLine( e );
// 			return BadRequest("Error updating shift");
// 		}
// 	}
// }