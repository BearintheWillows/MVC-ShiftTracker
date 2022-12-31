using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Migrations;

using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtentions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		//Shifts

		modelBuilder.Entity<Shift>()
		            .HasData( 
			             new Shift {
				             Id = -1,
				             RunId = 68,
				             StartTime = DateTime.Parse("2019-1-1 8:00:00"),
				             EndTime = DateTime.Parse("2019-1-1 16:00:00"),
				             TotalBreakLength = new TimeSpan( 30 ),
				             TotalShiftLength = new TimeSpan( 8 ),
				             TotalDriveLength = new TimeSpan( 4 ),
				             TotalWorkLength = new TimeSpan( 3, 30, 0 ), },
			             new Shift
						{
							Id = -2,
							RunId = 68,
							StartTime = DateTime.Parse("2019-1-1 10:00:00"),
							EndTime = DateTime.Parse("2019-1-1 14:00:00"),
							TotalBreakLength = new TimeSpan( 15 ),
							TotalShiftLength = new TimeSpan( 4 ),
							TotalDriveLength = new TimeSpan( 1 ),
							TotalWorkLength = new TimeSpan( 2, 45, 0 ),
						},
						new Shift
						{
						Id = -3,
						RunId = 68,
						StartTime = DateTime.Parse("2019-1-1 7:00:00"),
						EndTime = DateTime.Parse("2019-1-1 19:00:00"),
						TotalBreakLength = new TimeSpan( 1, 0, 0 ),
						TotalShiftLength = new TimeSpan( 12 ),
						TotalDriveLength = new TimeSpan( 6 ),
						TotalWorkLength = new TimeSpan( 5, 0, 0 ),
						}
					);
	}
}