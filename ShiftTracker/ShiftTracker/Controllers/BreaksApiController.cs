using Microsoft.AspNetCore.Mvc;

namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services;

[ApiController, Route( "api/breaks" )]
public class BreaksApiController : ControllerBase
{
	private readonly IBreakService _breakService;
	private readonly IShiftService _shiftService;

	public BreaksApiController(IBreakService breakService, IShiftService shiftService)
	{
		_breakService = breakService;
		_shiftService = shiftService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Break>>> GetBreaks()
	{
		try
		{
			var breaks = await _breakService.GetAllAsync();

			var breaksDto = breaks.Select( b => new BreakDto
					{
					Id = b.Id,
					StartTime = b.StartTime,
					EndTime = b.EndTime,
					Duration = b.EndTime - b.StartTime,
					ShiftId = b.ShiftId,
					}
			).ToList();

			return Ok( breaksDto );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpGet( "{id}" )]
	public async Task<ActionResult<Break>> GetBreak(int id)
	{
		try
		{
			var returnedBreak = await _breakService.GetAsync( id );

			if ( returnedBreak == null ) return NotFound("No Break by that Id found.");
			var breakDto = new BreakDto
				{
				Id = returnedBreak.Id,
				StartTime = returnedBreak.StartTime,
				EndTime = returnedBreak.EndTime,
				Duration = returnedBreak.EndTime - returnedBreak.StartTime,
				ShiftId = returnedBreak.ShiftId,
				};

			return Ok( breakDto );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpPost]
	public async Task<ActionResult<Break>> PostBreak(BreakDto breakDto)
	{
		try
		{
			if ( !await _shiftService.ExistsAsync(breakDto.ShiftId) ) return NotFound( "Shift does not exist" );
			if ( await _breakService.ExistsAsync(breakDto.Id) ) return NotFound( "Break already exists" );

			var newBreak = new Break
				{
				StartTime = breakDto.StartTime,
				EndTime = breakDto.EndTime,
				Duration = breakDto.EndTime - breakDto.StartTime,
				ShiftId = breakDto.ShiftId,
				};

			await _breakService.AddAsync( newBreak );

			return Ok( newBreak );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpDelete( "{id}" )]
	public async Task<ActionResult<Break>> DeleteBreak(int id)
	{
		try
		{
			var returnedBreak = await _breakService.GetAsync( id );

			if ( returnedBreak == null ) return NotFound( "Break does not exist" );

			await _breakService.DeleteAsync( id );

			return Ok( "Break Deleted Successfully" );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpPut( "{id}" )]
	public async Task<ActionResult<Break>> PutBreak(int id, [FromBody] BreakDto breakDto)
	{
		try
		{
			var returnedBreak = await _breakService.GetAsync( id );

			if ( returnedBreak == null )
			{
				return NotFound("No Break by that Id found.");
			}
			

			returnedBreak.StartTime = breakDto.StartTime;
			returnedBreak.EndTime = breakDto.EndTime;
			returnedBreak.Duration = breakDto.EndTime - breakDto.StartTime;

			await _breakService.UpdateAsync( returnedBreak );

			return Ok( returnedBreak );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}
}