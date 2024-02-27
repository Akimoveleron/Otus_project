using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Steads",
                type: "int"
                );

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Gardens",
                type: "int"
                );

            migrationBuilder.CreateIndex(
                name: "IX_Steads_PlantId",
                table: "Steads",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_PlantId",
                table: "Gardens",
                column: "PlantId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
