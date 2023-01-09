using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSequenceNum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes");

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "DailyRoutes");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WindowOpenTime",
                table: "DailyRoutes",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "RunId",
                table: "DailyRoutes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WindowOpenTime",
                table: "DailyRoutes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RunId",
                table: "DailyRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "DailyRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyRoutes",
                keyColumn: "Id",
                keyValue: -5,
                column: "SequenceNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DailyRoutes",
                keyColumn: "Id",
                keyValue: -4,
                column: "SequenceNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DailyRoutes",
                keyColumn: "Id",
                keyValue: -3,
                column: "SequenceNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DailyRoutes",
                keyColumn: "Id",
                keyValue: -2,
                column: "SequenceNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DailyRoutes",
                keyColumn: "Id",
                keyValue: -1,
                column: "SequenceNumber",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
