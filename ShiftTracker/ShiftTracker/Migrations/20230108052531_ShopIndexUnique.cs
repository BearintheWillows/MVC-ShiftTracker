using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftTracker.Migrations
{
    /// <inheritdoc />
    public partial class ShopIndexUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shops_Name_Number",
                table: "Shops",
                columns: new[] { "Name", "Number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_Name_Number",
                table: "Shops");
        }
    }
}
