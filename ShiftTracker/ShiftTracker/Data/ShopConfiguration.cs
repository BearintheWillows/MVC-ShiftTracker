namespace ShiftTracker.Data;

using Areas.Shifts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
	public void Configure(EntityTypeBuilder<Shop> builder)
	{
		builder.ToTable( "Shops" );
		builder.HasKey( s => s.Id );
		builder.Property( s => s.Postcode ).IsRequired().HasMaxLength( 5 );
		builder.Property( s => s.Street ).IsRequired().HasMaxLength( 50 );
		builder.Property( s => s.Street2 ).HasMaxLength( 50 );
		builder.Property( s => s.City ).IsRequired().HasMaxLength( 10 );
		builder.Property( s => s.County ).HasMaxLength( 20 );
		builder.Property( s => s.PhoneNumber ).HasMaxLength( 11 );
		builder.HasMany( s => s.DayVariants ).WithOne( dv => dv.Shop ).HasForeignKey( dv => dv.ShopId );
	}
}
