﻿namespace ShiftTracker.Areas.Shifts.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class RunConfiguration : IEntityTypeConfiguration<Run>
{
	public void Configure(EntityTypeBuilder<Run> builder)
	{
		builder.ToTable( "Runs" );
		builder.HasKey( r => r.Id );
		builder.Property( r => r.StartTime ).IsRequired();
	}
}