namespace ShiftTracker.Data;

using Microsoft.EntityFrameworkCore;
using Areas.Shifts.Models;
using Migrations;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ShiftConfiguration());
		modelBuilder.ApplyConfiguration( new BreakConfiguration() );
		modelBuilder.Seed();
	}

	public DbSet<Shift> Shifts { get; set; } 
	public DbSet<Break> Breaks { get; set; }
}