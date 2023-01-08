﻿namespace ShiftTracker.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using ShiftTracker.Areas.Shifts.Models;

public class DailyRoutePlanConfiguration : IEntityTypeConfiguration<DailyRoutePlan>
{
	public void Configure(EntityTypeBuilder<DailyRoutePlan> builder)
	{
		builder.ToTable( "Daily Route Plans" );
		builder.HasKey( s => s.Id );
		builder.HasIndex( s => new { s.ShopId, s.RunId, s.DayOfWeek } ).IsUnique();
		builder.Property( s => s.SequenceNumber ).IsRequired();
		builder.Property( s => s.DayOfWeek ).IsRequired();
		builder.Property( s => s.ShopId ).IsRequired();
		builder.Property( s => s.RunId ).IsRequired();
		builder.Property( s => s.WindowOpenTime ).IsRequired();
		builder.Property( s => s.WindowCloseTime ).IsRequired();
		builder.HasOne( s => s.Run ).WithMany( r => r.Shops ).HasForeignKey( s => s.RunId ).OnDelete( DeleteBehavior.Cascade );
		builder.HasOne( s => s.Shop ).WithMany( s => s.DayVariants ).HasForeignKey( s => s.ShopId ).OnDelete( DeleteBehavior.Cascade );
		builder.HasIndex( s => new { DeliverySequenceNumber = s.SequenceNumber, s.RunId, s.DayOfWeek } );
	}
}