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
			
			if ( run != null) return RunDto.CreateRunDto( run, includeDRP );
			
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
			if ( await _runService.ExistsAsync(runDto.Id) )
			{
				return BadRequest("Run already exists");
			}


			Run run = new Run { Number = runDto.Number, StartTime = runDto.StartTime };

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

	[HttpPut("{id}")]
	public async Task<ActionResult<RunDto>> UpdateRun(int id, [FromBody] RunDto runDto)
	{
		try
		{
			var run = await _runService.GetAsync( id, false );
			if (  run == null )
			{
				return NotFound( $"No run with Id {id} exists" );
			}
			//TODO: Change Number of any DRP's that are associated with this run
			
			Run newRun = new Run
				{
				Id = runDto.Id,
				Number = runDto.Number,
				StartTime = runDto.StartTime
				};
			
			await _runService.UpdateAsync( run );
			
			return Ok(runDto);
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error updating run" );
			Console.WriteLine( e );
			throw;
		}
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteRun(int id)
	{
		try
		{
			if ( !await _runService.ExistsAsync( id )  )
			{
				return NotFound($"No Run with Id {id} found.");
			}

			
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