using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersApp.Infrastructure.PG.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Workers",
                newName: "IsMan");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Workers",
                newName: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMan",
                table: "Workers",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Workers",
                newName: "Birthdate");
        }
    }
}
