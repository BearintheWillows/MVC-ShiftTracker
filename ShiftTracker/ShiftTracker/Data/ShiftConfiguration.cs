using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Data
{
    internal class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shifts");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Date).IsRequired();
            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();
            builder.Property(s => s.TotalHours).IsRequired();
            builder.Property(s => s.TotalBreakTime).IsRequired();
            builder.Property(s => s.TotalDrivingTime).IsRequired();
            builder.Property(s => s.TotalOtherWorkTime).IsRequired();
            builder.Property(s => s.TotalWorkTime).IsRequired();
            builder.HasMany(s => s.Breaks).WithOne(b => b.Shift).HasForeignKey(b => b.ShiftId);
            //has one identity user
            builder.HasOne(s => s.User).WithMany(u => u.Shifts).HasForeignKey(s => s.UserId);
        }
    }
}