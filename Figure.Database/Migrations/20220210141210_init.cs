using Microsoft.EntityFrameworkCore.Migrations;

namespace Figure.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Radius = table.Column<double>(type: "REAL", nullable: false),
                    CountOfAngles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Triangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SideA = table.Column<double>(type: "REAL", nullable: false),
                    SideB = table.Column<double>(type: "REAL", nullable: false),
                    SideC = table.Column<double>(type: "REAL", nullable: false),
                    CountOfAngles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triangles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Triangles");
        }
    }
}
