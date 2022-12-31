using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShiftTracker.Pages.Areas.Shifts.Pages;

using Data;
using ShiftTracker.Areas.Shifts.Models;

public class Index : PageModel
{
	public Index(ApplicationDbContext context)
	{
		_context = context;
	}
	
	private ApplicationDbContext _context { get; }
	public  ICollection<Shift>   Shifts   { get; set; }

	public void OnGet()
	{
		Shifts = _context.Shifts.ToList();
	}
	
}