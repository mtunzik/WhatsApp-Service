using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanosApp.API.Migrations
{
    public partial class NavBar_AddToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubIcon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CSSClass = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubIcon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AltText = table.Column<string>(type: "TEXT", nullable: true),
                    Src = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavBar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UId = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CssClass = table.Column<string>(type: "TEXT", nullable: true),
                    HRef = table.Column<string>(type: "TEXT", nullable: true),
                    SubIconId = table.Column<int>(type: "INTEGER", nullable: true),
                    SubImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavBar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavBar_SubIcon_SubIconId",
                        column: x => x.SubIconId,
                        principalTable: "SubIcon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NavBar_SubImage_SubImageId",
                        column: x => x.SubImageId,
                        principalTable: "SubImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavBar_SubIconId",
                table: "NavBar",
                column: "SubIconId");

            migrationBuilder.CreateIndex(
                name: "IX_NavBar_SubImageId",
                table: "NavBar",
                column: "SubImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavBar");

            migrationBuilder.DropTable(
                name: "SubIcon");

            migrationBuilder.DropTable(
                name: "SubImage");
        }
    }
}
