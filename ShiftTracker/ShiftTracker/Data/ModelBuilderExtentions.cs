using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Migrations;

using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtentions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		//Shifts

		modelBuilder.Entity<Shift>()
		            .HasData( new
				             {
				             Id = -1,
				             RunId = 68,
				             Date = new DateTime( 2023,1,1 ),
				             StartTime = new DateTime( 2019, 10, 1, 8, 0, 0 ),
				             EndTime = new DateTime( 2019, 10, 1, 16, 0, 0 ),
				             TotalShiftLength = new TimeSpan( 8, 0, 0 ),
				             TotalBreakLength = new TimeSpan( 0, 30, 0 ),
				             TotalDriveLength = new TimeSpan( 3, 30, 0 ),
				             TotalOtherWorkLength = new TimeSpan( 0, 30, 0 ),
				             TotalWorkLength = new TimeSpan( 4, 0, 0 )
				             }
		             );
	}
}