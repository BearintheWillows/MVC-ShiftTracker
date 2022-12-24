using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftTracker.Areas.Shifts.Models;

namespace ShiftTracker.Data
{
    internal class BreakConfiguration : IEntityTypeConfiguration<Break>
    {
        public void Configure(EntityTypeBuilder<Break> builder)
        {
            builder.ToTable("Breaks");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Date).IsRequired();
            builder.Property(b => b.StartTime).IsRequired();
            builder.Property(b => b.EndTime).IsRequired();
            builder.Property(b => b.Duration).IsRequired();
        }
    }
}