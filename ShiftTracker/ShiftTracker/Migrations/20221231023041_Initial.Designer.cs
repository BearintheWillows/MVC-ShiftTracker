﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShiftTracker.Data;

#nullable disable

namespace ShiftTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221231023041_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<TimeSpan>("TotalShiftLength")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TotalWorkLength")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Shifts", (string)null);
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
