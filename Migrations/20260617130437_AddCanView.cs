using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCanView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "can_view",
                table: "menu_access",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "can_view",
                table: "menu_access");
        }
    }
}
