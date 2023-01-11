﻿namespace ShiftTracker.Areas.Shifts.Controllers;

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
     
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}
	
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Date, RunId, StartTime, EndTime, DriveTime, OtherWorkTime, WorkTime")] Shift shift)
	{
		
			await _shiftService.AddAsync( shift );
			return RedirectToAction("Index");
	}

}