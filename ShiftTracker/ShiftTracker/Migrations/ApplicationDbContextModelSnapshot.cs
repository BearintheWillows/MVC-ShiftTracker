﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShiftTracker.Data;

#nullable disable

namespace ShiftTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShiftTracker.Areas.Shifts.Models.Break", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ShiftId");

                    b.ToTable("Breaks", (string)null);
                });

            modelBuilder.Entity("ShiftTracker.Areas.Shifts.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RunId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("TotalBreakLength")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TotalDriveLength")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TotalOtherWorkLength")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TotalShiftLength")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TotalWorkLength")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Shifts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new DateTime(2019, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            RunId = 68,
                            StartTime = new DateTime(2019, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalBreakLength = new TimeSpan(0, 0, 30, 0, 0),
                            TotalDriveLength = new TimeSpan(0, 3, 30, 0, 0),
                            TotalOtherWorkLength = new TimeSpan(0, 0, 30, 0, 0),
                            TotalShiftLength = new TimeSpan(0, 8, 0, 0, 0),
                            TotalWorkLength = new TimeSpan(0, 4, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("ShiftTracker.Areas.Shifts.Models.Break", b =>
                {
                    b.HasOne("ShiftTracker.Areas.Shifts.Models.Shift", "Shift")
                        .WithMany("Breaks")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("ShiftTracker.Areas.Shifts.Models.Shift", b =>
                {
                    b.Navigation("Breaks");
                });
#pragma warning restore 612, 618
        }
    }
}
