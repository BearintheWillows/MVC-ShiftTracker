namespace ShiftTracker.Areas.Shifts.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShiftTracker.Data.Models;
using Services;

[Area("Shifts")]
public class HomeController : Controller
{
	private readonly IShiftService _shiftService;

	public HomeController(IShiftService shiftService)
	{
		_shiftService = shiftService;
	}

	public async Task<IActionResult> Index()
	{
		IEnumerable<Shift> shiftQuery = await _shiftService.GetAllAsync(true, true, true);

		shiftQuery.AsQueryable().OrderBy( s => s.Date );
		
		return View(shiftQuery);
	}

	public string GetAmOrPm(int hour)
	{
		return hour < 12 ? "AM" : "PM";
	}


}