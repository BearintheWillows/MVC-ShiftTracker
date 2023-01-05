using Microsoft.AspNetCore.Mvc;

namespace ShiftTracker.Controllers;

public class BreaksApiController : Controller
{
	// GET
	public IActionResult Index()
	{
		return View();
	}
}