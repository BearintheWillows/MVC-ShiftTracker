using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstructorsToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalWorkLength",
                table: "Shifts",
                newName: "WorkTime");

            migrationBuilder.RenameColumn(
                name: "TotalShiftLength",
                table: "Shifts",
                newName: "ShiftDuration");

            migrationBuilder.RenameColumn(
                name: "TotalOtherWorkLength",
                table: "Shifts",
                newName: "OtherWorkTime");

            migrationBuilder.RenameColumn(
                name: "TotalDriveLength",
                table: "Shifts",
                newName: "DriveTime");

            migrationBuilder.RenameColumn(
                name: "TotalBreakLength",
                table: "Shifts",
                newName: "BreakDuration");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Breaks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Duration", "EndTime" },
                values: new object[] { new TimeSpan(0, 0, 15, 0, 0), new DateTime(2020, 1, 1, 14, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Duration", "EndTime" },
                values: new object[] { new TimeSpan(0, 1, 0, 0, 0), new DateTime(2020, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Breaks",
                columns: new[] { "Id", "Duration", "EndTime", "ShiftId", "StartTime" },
                values: new object[] { -3, new TimeSpan(0, 0, 30, 0, 0), new DateTime(2020, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), -1, new DateTime(2020, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "BreakDuration", "Date", "EndTime", "ShiftDuration", "StartTime", "WorkTime" },
                values: new object[] { new TimeSpan(0, 0, 0, 0, 0), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 17, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 15, 0, 0), new DateTime(2020, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "BreakDuration", "Date", "DriveTime", "EndTime", "OtherWorkTime", "RunId", "ShiftDuration", "StartTime", "WorkTime" },
                values: new object[] { -2, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 30, 0, 0), new DateTime(2023, 1, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 30, 0, 0), 19, new TimeSpan(0, 12, 30, 0, 0), new DateTime(2023, 1, 2, 4, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Breaks",
                columns: new[] { "Id", "Duration", "EndTime", "ShiftId", "StartTime" },
                values: new object[,]
                {
                    { -5, new TimeSpan(0, 0, 45, 0, 0), new DateTime(2023, 1, 1, 16, 45, 0, 0, DateTimeKind.Unspecified), -2, new DateTime(2023, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -4, new TimeSpan(0, 0, 30, 0, 0), new DateTime(2023, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), -2, new DateTime(2023, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Breaks");

            migrationBuilder.RenameColumn(
                name: "WorkTime",
                table: "Shifts",
                newName: "TotalWorkLength");

            migrationBuilder.RenameColumn(
                name: "ShiftDuration",
                table: "Shifts",
                newName: "TotalShiftLength");

            migrationBuilder.RenameColumn(
                name: "OtherWorkTime",
                table: "Shifts",
                newName: "TotalOtherWorkLength");

            migrationBuilder.RenameColumn(
                name: "DriveTime",
                table: "Shifts",
                newName: "TotalDriveLength");

            migrationBuilder.RenameColumn(
                name: "BreakDuration",
                table: "Shifts",
                newName: "TotalBreakLength");

            migrationBuilder.UpdateData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2020, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Breaks",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2020, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Date", "EndTime", "StartTime", "TotalBreakLength", "TotalShiftLength", "TotalWorkLength" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 30, 0, 0), new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 4, 0, 0, 0) });
        }
    }
}
