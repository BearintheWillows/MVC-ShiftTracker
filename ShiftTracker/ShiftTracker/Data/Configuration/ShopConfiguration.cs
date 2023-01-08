﻿namespace ShiftTracker.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using ShiftTracker.Areas.Shifts.Models;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
	public void Configure(EntityTypeBuilder<Shop> builder)
	{
		builder.ToTable( "Shops" );
		builder.HasKey( s => s.Id );
		builder.Property( s => s.Postcode ).IsRequired().HasMaxLength( 20);
		builder.Property( s => s.Street ).IsRequired().HasMaxLength( 50 );
		builder.Property( s => s.Street2 ).HasMaxLength( 50 );
		builder.Property( s => s.City ).IsRequired().HasMaxLength( 20 );
		builder.Property( s => s.County ).HasMaxLength( 20 );
		builder.Property( s => s.PhoneNumber ).HasMaxLength( 20 );
		builder.Property(s => s.Name).IsRequired().HasMaxLength(30);
		builder.HasMany( s => s.DailyRoutePlan).WithOne( dv => dv.Shop ).HasForeignKey( dv => dv.ShopId );
		builder.HasIndex( s => new { s.Name, s.Number } ).IsUnique();
	}
}
