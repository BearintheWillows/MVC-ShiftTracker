using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Migrations;

using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtentions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		//Shifts

		modelBuilder.Entity<Break>()
		            .HasData( );

	modelBuilder.Entity<Shift>()
		            .HasData( );
	}
}