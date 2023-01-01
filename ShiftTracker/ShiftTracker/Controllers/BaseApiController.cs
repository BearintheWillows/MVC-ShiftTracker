namespace ShiftTracker.Controllers;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Serilog;

public abstract class BaseApiController<TEntity> : ControllerBase where TEntity : class
{
	private readonly ApplicationDbContext _context;


	protected BaseApiController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		try
		{
			List<TEntity> result = await _context.Set<TEntity>().ToListAsync();
			Log.Information( LogResponseHelper.GetDBSuccess( typeof(TEntity) ) );
			Log.Information( LogResponseHelper.CollectionCount( typeof(TEntity), result ) );
			return Ok( result );
		}
		catch ( Exception e )
		{
			Console.WriteLine( e );
			Log.Error( e, LogResponseHelper.GetDBError( typeof(TEntity) ) );
			return BadRequest( e.Message );
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		try
		{
			var result = await _context.Set<TEntity>().FindAsync( id );
			Log.Information( LogResponseHelper.GetDBSuccess( typeof(TEntity) ) );
			return Ok( result );
		}
		catch ( Exception e )
		{
			Log.Error( LogResponseHelper.GetDBError( typeof(TEntity) ) );
			Log.Error( e.Message );
			return BadRequest( e.Message );
		}
	
	}
}