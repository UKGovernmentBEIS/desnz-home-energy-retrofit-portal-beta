using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerPortal.Data.Migrations
{
    public partial class UserDisabledField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Users");
        }
    }
}
