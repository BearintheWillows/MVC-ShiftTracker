using Microsoft.AspNetCore.Mvc;

namespace ShiftTracker.Areas.Shifts.Controllers;

using Areas.Shifts.Models;
using Data;
using ShiftTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsApiController : BaseApiController<Shift>
{

	public ShiftsApiController(ApplicationDbContext context) : base( context )
	{
		
	}
	
}