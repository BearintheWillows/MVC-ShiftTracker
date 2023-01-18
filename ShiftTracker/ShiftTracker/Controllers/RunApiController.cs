namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;

[ApiController, Route( "api/runs" )]
public class RunApiController : ControllerBase
{
	private readonly IDailyRoutePlanService _dRPService;
	private readonly IRunService            _runService;
	private readonly IShopService           _shopService;

	public RunApiController(IRunService runService, IDailyRoutePlanService dRpService, IShopService shopService)
	{
		_runService = runService;
		_dRPService = dRpService;
		_shopService = shopService;
	}

	[HttpGet]
	public async Task<ActionResult<List<RunDto>>> GetAllRuns([FromQuery] bool includeDRP = false)
	{
		try
		{
			var runResultAsync = await _runService.GetAllAsync( includeDRP );

			var results = RunDto.CreateDtoList( runResultAsync, includeDRP );

			return Ok( results );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest();
		}
	}

	[HttpGet( "{id}" )]
	public async Task<ActionResult<RunDto?>> GetRunById(int id, [FromQuery] bool includeDRP = false)
	{
		try
		{
			var run = await _runService.GetAsync( id, includeDRP );

			if ( run != null ) return RunDto.CreateRunDto( run, includeDRP );

			return NotFound( "Run Doesn't exist" );
		}
		catch ( Exception e )
		{
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpPost]
	public async Task<ActionResult<RunDto>> AddRun([FromBody] RunDto runDto)
	{
		try
		{
			if ( await _runService.ExistsAsync( runDto.Id ) ) return BadRequest( "Run already exists" );


			var run = new Run { Number = runDto.Number, StartTime = runDto.StartTime };

			await _runService.AddAsync( run );

			return Ok( RunDto.CreateRunDto( run, false ) );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error adding run" );
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpPut( "{id}" )]
	public async Task<ActionResult<RunDto>> UpdateRun(int id, [FromBody] RunDto runDto)
	{
		try
		{
			var run = await _runService.GetAsync( id, false );
			if ( run == null ) return NotFound( $"No run with Id {id} exists" );

			var newRun = new Run { Id = runDto.Id, Number = runDto.Number, StartTime = runDto.StartTime };

			await _runService.UpdateAsync( run );

			return Ok( runDto );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error updating run" );
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpDelete( "{id}" )]
	public async Task<ActionResult> DeleteRun(int id)
	{
		try
		{
			if ( !await _runService.ExistsAsync( id ) ) return NotFound( $"No Run with Id {id} found." );


			await _runService.DeleteAsync( id );
			return Ok();
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error deleting run" );
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpGet( "{id}/routes" )]
	public async Task<List<DailyRoutePlan>> GetRoutesForRun(int id, [FromQuery] DayOfWeek? day)
	{
		try
		{
			if ( day == null ) return await _dRPService.GetRoutesForRunAsync( id );
			return await _dRPService.GetRouteForRunDayFilterAsync( id, day.Value );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting routes for run" );
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpPost( "{id}/routes/" )]
	public async Task<ActionResult<DailyRoutePlan>> AddRouteToRun(int id, [FromBody] DailyRoutePlanDto drpDto)
	{
		try
		{
			if ( !await _runService.ExistsAsync( id ) ) return NotFound( $"No Run with Id {id} found." );

			if ( !await _shopService.ExistsAsync( drpDto.ShopId ) )
				return NotFound( $"No Shop with Id {drpDto.ShopId} found." );

			var route = new DailyRoutePlan
				{
				RunId = drpDto.RunId,
				ShopId = drpDto.ShopId,
				DayOfWeek = ( DayOfWeek ) drpDto.DayOfWeek,
				WindowOpenTime = drpDto.WindowOpenTime,
				WindowCloseTime = drpDto.WindowCloseTime,
				};

			await _dRPService.AddAsync( route );

			return Ok( drpDto );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error adding route to run" );
			Console.WriteLine( e );
			throw;
		}
	}
}