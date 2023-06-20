using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scrum_Mvc_GroupProject.Migrations
{
    public partial class CreatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscussieThreads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentaar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForumCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussieThreads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussieThreads_ForumCategories_ForumCategoryId",
                        column: x => x.ForumCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reacties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentaar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscussieThreadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reacties_DiscussieThreads_DiscussieThreadId",
                        column: x => x.DiscussieThreadId,
                        principalTable: "DiscussieThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussieThreads_ForumCategoryId",
                table: "DiscussieThreads",
                column: "ForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacties_DiscussieThreadId",
                table: "Reacties",
                column: "DiscussieThreadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reacties");

            migrationBuilder.DropTable(
                name: "DiscussieThreads");

            migrationBuilder.DropTable(
                name: "ForumCategories");
        }
    }
}
