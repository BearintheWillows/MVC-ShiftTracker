using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedShopNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -5,
                column: "Number",
                value: 1223);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -4,
                column: "Number",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -3,
                column: "Number",
                value: 2004);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -2,
                column: "Number",
                value: 2005);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -1,
                column: "Number",
                value: 2006);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Shops");
        }
    }
}
