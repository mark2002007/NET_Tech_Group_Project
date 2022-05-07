using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_Basics_Project.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotlines",
                columns: table => new
                {
                    HotlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Number = table.Column<string>(maxLength: 16, nullable: false),
                    Area = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotlines", x => x.HotlineID);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 2024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_Volunteers_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_VolunteerID",
                table: "Services",
                column: "VolunteerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotlines");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
