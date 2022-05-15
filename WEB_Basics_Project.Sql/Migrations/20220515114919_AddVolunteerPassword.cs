using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_Basics_Project.Sql.Migrations
{
    public partial class AddVolunteerPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Volunteers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Volunteers");
        }
    }
}
