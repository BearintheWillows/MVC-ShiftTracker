using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedShopName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shops",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -5,
                column: "Name",
                value: "One Stop");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -4,
                column: "Name",
                value: "Aldi");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -3,
                column: "Name",
                value: "Tesco");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -2,
                column: "Name",
                value: "Tesco");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "Tesco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shops");
        }
    }
}
