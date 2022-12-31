using Microsoft.AspNetCore.Mvc;

namespace ShiftTracker.Controllers;

using Areas.Shifts.Models;
using Data;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : BaseApiController<Shift>
{

	public ShiftsController(ApplicationDbContext context) : base( context )
	{
		
	}
	
}