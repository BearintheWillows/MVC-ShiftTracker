namespace ShiftTracker.Controllers;

using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

public abstract class BaseApiController<TEntity> : ControllerBase where TEntity : class
{
	private readonly ApplicationDbContext _context;


	protected BaseApiController(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> GetAll()
	{
		try
		{
			List<TEntity> result = await _context.Set<TEntity>().ToListAsync();
			Log.Information( $"List of {typeof(TEntity).Name} returned successfully" );
			Log.Information( $"{typeof(TEntity).Name} contains {result.Count} record." );
			return Ok( result );
		}
		catch ( Exception e )
		{
			Console.WriteLine( e );
			Log.Error( e, "Get all {0}", typeof(TEntity).Name );
			return BadRequest( e.Message );
		}
	}

	public async Task<IActionResult> Get(int id)
	{
		try
		{
			var result = await _context.Set<TEntity>().FindAsync( id );
			Log.Information( $"Get {typeof(T).Name} with id {id} SUCCESS" );
			return Ok( result );
		}
		catch ( Exception e )
		{
			Log.Error( $"Get {typeof(T)} with id {id} FAILED" );
			Log.Debug( e.Message );
			return BadRequest( e.Message );
		}
	
	}
}