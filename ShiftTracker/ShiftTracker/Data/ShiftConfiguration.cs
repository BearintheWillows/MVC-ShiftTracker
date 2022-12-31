namespace ShiftTracker.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Areas.Shifts.Models;

public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
{
	public void Configure(EntityTypeBuilder<Shift> builder)
	{
		builder.ToTable( "Shifts" );
		builder.HasKey( s => s.Id );
		builder.Property( s => s.Id ).ValueGeneratedOnAdd();
		builder.Property( s => s.StartTime ).IsRequired();
		builder.Property( s => s.EndTime ).IsRequired();
		builder.Property( s => s.TotalBreakLength ).IsRequired();
		builder.Property( s => s.TotalDriveLength ).IsRequired();
		builder.Property( s => s.TotalShiftLength ).IsRequired();
		builder.Property( s => s.TotalWorkLength ).IsRequired();
		builder.HasMany<Break>(s => s.Breaks).WithOne(b => b.Shift).HasForeignKey(b => b.ShiftId).OnDelete( DeleteBehavior.Cascade );
	}
}
