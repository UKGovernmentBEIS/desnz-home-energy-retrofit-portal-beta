using HerPortal.BusinessLogic.Models.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerPortal.Data.Migrations
{
    public partial class UserRoleField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: UserRole.LocalAuthorityStaff);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
