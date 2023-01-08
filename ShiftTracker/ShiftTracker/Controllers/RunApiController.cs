namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;

[ApiController, Route( "api/runs" )]

public class RunApiController : ControllerBase
{
	private readonly IRunService            _runService;
	private readonly IDailyRoutePlanService _dRPService;

	public RunApiController(IRunService runService, IDailyRoutePlanService dRpService)
	{
		_runService = runService;
		_dRPService = dRpService;
	}

	[HttpGet]
	public async Task<ActionResult<List<RunDto>>> GetAllRuns([FromQuery] bool includeDRP = false)
	{
		try
		{
			List<Run> runResultAsync = await _runService.GetAllAsync( includeDRP );

			IEnumerable<RunDto> results = RunDto.CreateDtoList( runResultAsync, includeDRP );

			return Ok( results );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest();
		}
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<RunDto?>> GetRunById(int id, [FromQuery] bool includeDRP = false)
	{
		try
		{
			Run? run = await _runService.GetAsync( id, includeDRP );
			
			if ( run != null) return RunDto.CreateDto( run, includeDRP );
			
			return NotFound( "Run Doesn't exist" );
		}
		catch ( Exception e )
		{
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpPost]
	public async Task<ActionResult<RunDto>> AddRunAndRoutes([FromBody] RunDto runDto)
	{
		 		try
		{
			if ( await _runService.ExistsAsync(runDto.Id) )
			{
				return BadRequest("Run already exists");
			}


			Run run = new Run { Number = runDto.Number, StartTime = runDto.StartTime };
			
			var storedRun = await _runService.AddAsync( run );

			List<DailyRoutePlan> dailyRoutes = new List<DailyRoutePlan>();

			for ( int i = 0; i < 7; i++ )
			{
				DailyRoutePlan dayRoute = new DailyRoutePlan
					{
					DayOfWeek = ( DayOfWeek ) i + 1, RunId = storedRun.Id,
					};
				
				dailyRoutes.Add( dayRoute );
			}
			
			await _dRPService.AddRangeAsync( dailyRoutes );
			
			return Ok( "ok" );

		}
		catch ( Exception e )
		{
			Log.Error( e, "Error adding run" );
			Console.WriteLine( e );
			throw;
		}
	}

	// [HttpPut]
	// public async Task<ActionResult<RunDto>> UpdateRun([FromBody] RunDto runDto)
	// {
	// 	try
	// 	{
	// 		Run run = await _runService.UpdateAsync( runDto );
	// 		return RunDto.CreateDto( run, true );
	// 	}
	// 	catch ( Exception e )
	// 	{
	// 		Log.Error( e, "Error updating run" );
	// 		Console.WriteLine( e );
	// 		throw;
	// 	}
	// }

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteRun(int id)
	{
		try
		{
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
}