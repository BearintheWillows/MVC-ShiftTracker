namespace ShiftTracker.Areas.Shifts.Controllers;

using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services;

[Area( "Shifts" )]
public class HomeController : Controller
{
	private readonly IBreakService _breakService;
	private readonly IRunService   _runService;
	private readonly IShiftService _shiftService;

	public HomeController(IShiftService shiftService, IBreakService breakService, IRunService runService)
	{
		_shiftService = shiftService;
		_breakService = breakService;
		_runService = runService;
	}

	public async Task<IActionResult> Index()
	{
		IEnumerable<Shift> shiftQuery = await _shiftService.GetAllAsync( true, true, true );

		shiftQuery.AsQueryable().OrderBy( s => s.Date );

		return View( shiftQuery );
	}

	[HttpGet, Route( "/Create" )]
	public async Task<IActionResult> Create()
	{
		var runNumbers = await _runService.GetAllNumbersAndIds();

		ViewBag.runNumbers = runNumbers;

		return View();
	}

	[HttpPost, Route( "/Create" )]
	public async Task<IActionResult> Create(
		[Bind( "Date, RunId, StartTime, EndTime, DriveTime, OtherWorkTime, WorkTime" )]
		ShiftDto shiftDto
	)
	{
		var shift = new Shift
			{
			Date = shiftDto.Date,
			RunId = shiftDto.RunId,
			StartTime = shiftDto.StartTime,
			EndTime = shiftDto.EndTime,
			DriveTime = shiftDto.DriveTime,
			OtherWorkTime = shiftDto.OtherWorkTime,
			WorkTime = shiftDto.WorkTime,
			ShiftDuration = shiftDto.EndTime - shiftDto.StartTime,
			};


		await _shiftService.AddAsync( shift );
		return RedirectToAction( "Index" );
	}

	public async Task<TimeSpan> CalculateBreakDuration(int shiftId)
	{
		var breakQuery = await _breakService.GetAllAsyncByShiftId( shiftId );
		var breakDuration = new TimeSpan();
		foreach ( var b in breakQuery ) breakDuration += b.Duration;

		return breakDuration;
	}
}