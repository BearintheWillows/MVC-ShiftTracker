namespace ShiftTracker.Areas.Shifts.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using ShiftTracker.Data.Models;
using Services;

[Area( "Shifts" )]
public class HomeController : Controller
{
	private readonly IShiftService _shiftService;
	private readonly IBreakService _breakService;

	public HomeController(IShiftService shiftService, IBreakService breakService)
	{
		_shiftService = shiftService;
		_breakService = breakService;
	}

	public async Task<IActionResult> Index()
	{
		IEnumerable<Shift> shiftQuery = await _shiftService.GetAllAsync( true, true, true );

		shiftQuery.AsQueryable().OrderBy( s => s.Date );

		return View( shiftQuery );
	}

	[HttpGet]
	[Route( "/Create" )]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(
		[Bind( "Date, RunId, StartTime, EndTime, DriveTime, OtherWorkTime, WorkTime" )] ShiftDto shiftDto
	)
	{


		Shift shift = new Shift
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
		IEnumerable<Break> breakQuery = await _breakService.GetAllAsyncByShiftId( shiftId );
		TimeSpan breakDuration = new TimeSpan();
		foreach ( Break b in breakQuery )
		{
			breakDuration += b.Duration;
		}

		return breakDuration;

	}
}