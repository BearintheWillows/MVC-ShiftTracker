namespace ShiftTracker.Areas.Shifts.Controllers.ApiControllers;

using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using ShiftTracker.Areas.Shifts.Models.DTO;

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

			if ( returnedBreak == null ) return NotFound( "No Break by that Id found." );
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
	public async Task<ActionResult> PostBreak(IEnumerable<BreakDto> breakDtoEnumerable)
	{
		var breakList = new List<Break>();
		foreach ( var breakDto in breakDtoEnumerable )
		{
			var newBreak = new Break
				{
				StartTime = breakDto.StartTime, EndTime = breakDto.EndTime, ShiftId = breakDto.ShiftId,
				};

			breakList.Add( newBreak );
		}

		try
		{
			await _breakService.PostAllBreaksAsync( breakList );
		}
		catch ( Exception e )
		{
			Console.WriteLine( e );
			throw;
		}

		return Ok();

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

			if ( returnedBreak == null ) return NotFound( "No Break by that Id found." );


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