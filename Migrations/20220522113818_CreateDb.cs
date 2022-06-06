using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AH_Project.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelCaptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Id = table.Column<int>(type: "int", nullable: false),
                    Model_Id = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCaptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimilarCaptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Id = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarCaptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCaptionId = table.Column<int>(type: "int", nullable: false),
                    Diversity = table.Column<int>(type: "int", nullable: false),
                    Novality = table.Column<int>(type: "int", nullable: false),
                    Informativeness = table.Column<int>(type: "int", nullable: false),
                    Fluency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_ModelCaptions_ModelCaptionId",
                        column: x => x.ModelCaptionId,
                        principalTable: "ModelCaptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ModelCaptionId",
                table: "Evaluations",
                column: "ModelCaptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "SimilarCaptions");

            migrationBuilder.DropTable(
                name: "ModelCaptions");
        }
    }
}
