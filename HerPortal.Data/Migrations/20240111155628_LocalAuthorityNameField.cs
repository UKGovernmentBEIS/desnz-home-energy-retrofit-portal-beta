using HerPortal.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerPortal.Data.Migrations
{
    public partial class LocalAuthorityNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LocalAuthorities",
                type: "text",
                nullable: true);

            foreach (var (laId, name) in LocalAuthorityData.LocalAuthorityNamesByCustodianCode)
            {
                migrationBuilder.UpdateData(
                    table: "LocalAuthorities",
                    keyColumn: "CustodianCode",
                    keyValue: laId,
                    column: "Name",
                    value: name);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LocalAuthorities");
        }
    }
}
