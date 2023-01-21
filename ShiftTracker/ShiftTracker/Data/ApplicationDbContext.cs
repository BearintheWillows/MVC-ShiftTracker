namespace ShiftTracker.Data;

using Areas.Shifts.Data;
using Microsoft.EntityFrameworkCore;
using ShiftTracker.Areas.Shifts.Data.Configuration;
using ShiftTracker.Areas.Shifts.Data.Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base( options )
	{ }

	public DbSet<Shift> Shifts { get; set; }
	public DbSet<Break> Breaks { get; set; }

	public DbSet<Run> Runs
	{
		get;
		set;
	}

	public DbSet<Shop?> Shops
	{
		get;
		set;
	}

	public DbSet<DailyRoutePlan> DailyRoutes
	{
		get;
		set;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration( new ShiftConfiguration() );
		modelBuilder.ApplyConfiguration( new BreakConfiguration() );
		modelBuilder.ApplyConfiguration( new RunConfiguration() );
		modelBuilder.ApplyConfiguration( new ShopConfiguration() );
		modelBuilder.Seed();
	}
}