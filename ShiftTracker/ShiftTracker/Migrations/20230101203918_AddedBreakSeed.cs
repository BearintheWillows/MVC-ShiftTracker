using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedBreakSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breaks",
                columns: new[] { "Id", "EndTime", "ShiftId", "StartTime" },
                values: new object[] { -2, new DateTime(2020, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), -1, new DateTime(2020, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -2);
        }
    }
}
