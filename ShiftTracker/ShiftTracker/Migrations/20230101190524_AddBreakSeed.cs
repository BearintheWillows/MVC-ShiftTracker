using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddBreakSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breaks",
                columns: new[] { "Id", "EndTime", "ShiftId", "StartTime" },
                values: new object[] { -1, new DateTime(2020, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), -1, new DateTime(2020, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
