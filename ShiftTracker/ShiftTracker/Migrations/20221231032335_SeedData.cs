﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "EndTime", "RunId", "StartTime", "TotalBreakLength", "TotalDriveLength", "TotalShiftLength", "TotalWorkLength" },
                values: new object[,]
                {
                    { -3, new DateTime(2019, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 68, new DateTime(2019, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0), new TimeSpan(6), new TimeSpan(12), new TimeSpan(0, 5, 0, 0, 0) },
                    { -2, new DateTime(2019, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 68, new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(15), new TimeSpan(1), new TimeSpan(4), new TimeSpan(0, 2, 45, 0, 0) },
                    { -1, new DateTime(2019, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 68, new DateTime(2019, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(30), new TimeSpan(4), new TimeSpan(8), new TimeSpan(0, 3, 30, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
