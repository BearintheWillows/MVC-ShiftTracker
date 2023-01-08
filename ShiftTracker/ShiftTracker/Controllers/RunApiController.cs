namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;

[ApiController, Route("api/runs")]

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

				IEnumerable<RunDto> results = RunDto.CreateDto( runResultAsync, includeDRP );
				
				return Ok( results );
			}
			catch ( Exception e )
			{
				Log.Error( e, "Error getting shifts" );
				Console.WriteLine( e );
				return BadRequest();
			}
	}
	}