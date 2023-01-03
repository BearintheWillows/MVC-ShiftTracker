namespace ShiftTracker.Data;

using Areas.Shifts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


	public class RunConfiguration : IEntityTypeConfiguration<Run>
	{
		public void Configure(EntityTypeBuilder<Run> builder)
		{
			builder.ToTable( "Runs" );
			builder.HasKey( r => r.Id );
			builder.Property( r => r.StartTime ).IsRequired();
		}
	}
