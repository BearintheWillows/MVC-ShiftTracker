using Microsoft.AspNetCore.Mvc;

namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

[ApiController, Route( "api/breaks" )]
public class BreaksApiController : ControllerBase
{
	private readonly ApplicationDbContext _context;

	public BreaksApiController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Break>>> GetBreaks()
	{
		try
		{
			var breaks = await _context.Breaks.ToListAsync();

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
			var returnedBreak = await _context.Breaks.FindAsync( id );

			if ( returnedBreak == null ) return NotFound( null );
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
			if ( _context.Shifts.Any( s => s.Id == breakDto.ShiftId ) == false )
				return BadRequest( "Shift does not exist" );
			if ( _context.Breaks.Any( b => b.Id == breakDto.Id ) ) return BadRequest( "Break already exists" );

			var newBreak = new Break
				{
				StartTime = breakDto.StartTime,
				EndTime = breakDto.EndTime,
				Duration = breakDto.EndTime - breakDto.StartTime,
				ShiftId = breakDto.ShiftId,
				};

			_context.Breaks.Add( newBreak );
			await _context.SaveChangesAsync();

			return Ok( newBreak );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpDelete( "delete/{id}" )]
	public async Task<ActionResult<Break>> DeleteBreak(int id)
	{
		try
		{
			var returnedBreak = _context.Breaks.Find( id );

			if ( returnedBreak == null ) return NotFound( "Break does not exist" );

			_context.Breaks.Remove( returnedBreak );
			await _context.SaveChangesAsync();

			return Ok( returnedBreak );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}

	[HttpPut( "update/{id}" )]
	public async Task<ActionResult<Break>> PutBreak(int id, [FromBody] BreakDto breakDto)
	{
		try
		{
			if ( _context.Breaks.Any( b => b.Id == breakDto.Id ) == false ) return BadRequest( "Break does not exist" );

			var returnedBreak = await _context.Breaks.FindAsync( id );

			if ( _context.Shifts.Any( s => s.Id == returnedBreak!.ShiftId ) == false )
				return BadRequest( "Shift does not exist" );

			returnedBreak.StartTime = breakDto.StartTime;
			returnedBreak.EndTime = breakDto.EndTime;
			returnedBreak.Duration = breakDto.EndTime - breakDto.StartTime;

			_context.Breaks.Update( returnedBreak );
			await _context.SaveChangesAsync();

			return Ok( returnedBreak );
		}
		catch ( Exception e )
		{
			return BadRequest( e.Message );
		}
	}
}