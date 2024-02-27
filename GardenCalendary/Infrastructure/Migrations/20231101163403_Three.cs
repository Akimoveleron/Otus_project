using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Gardens_Plants_Plantid",
            //    table: "Gardens");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Steads_Plants_Plantid",
            //    table: "Steads"); 

            migrationBuilder.RenameColumn(
                name: "Plantname",
                table: "Gardens",
                newName: "PlantName");

            migrationBuilder.RenameColumn(
                name: "Dateweeding",
                table: "Gardens",
                newName: "DateWeeding");

            migrationBuilder.RenameColumn(
                name: "Datewatering",
                table: "Gardens",
                newName: "DateWatering");

            migrationBuilder.RenameColumn(
                name: "Dateloosening",
                table: "Gardens",
                newName: "DateLoosening");

            migrationBuilder.RenameColumn(
                name: "Datehoeing",
                table: "Gardens",
                newName: "DateHoeing");

            migrationBuilder.RenameColumn(
                name: "Dateharvesting",
                table: "Gardens",
                newName: "DateHarvesting");

            migrationBuilder.RenameColumn(
                name: "Dateplantingt",
                table: "Gardens",
                newName: "DatePlanting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Plants_PlantId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Steads_Plants_PlantId",
                table: "Steads");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Steads",
                newName: "Plantid");

            migrationBuilder.RenameIndex(
                name: "IX_Steads_PlantId",
                table: "Steads",
                newName: "IX_Steads_Plantid");

            migrationBuilder.RenameColumn(
                name: "PlantName",
                table: "Gardens",
                newName: "Plantname");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Gardens",
                newName: "Plantid");

            migrationBuilder.RenameColumn(
                name: "DateWeeding",
                table: "Gardens",
                newName: "Dateweeding");

            migrationBuilder.RenameColumn(
                name: "DateWatering",
                table: "Gardens",
                newName: "Datewatering");

            migrationBuilder.RenameColumn(
                name: "DateLoosening",
                table: "Gardens",
                newName: "Dateloosening");

            migrationBuilder.RenameColumn(
                name: "DateHoeing",
                table: "Gardens",
                newName: "Datehoeing");

            migrationBuilder.RenameColumn(
                name: "DateHarvesting",
                table: "Gardens",
                newName: "Dateharvesting");

            migrationBuilder.RenameColumn(
                name: "DatePlanting",
                table: "Gardens",
                newName: "Dateplantingt");

            migrationBuilder.RenameIndex(
                name: "IX_Gardens_PlantId",
                table: "Gardens",
                newName: "IX_Gardens_Plantid");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Plants_Plantid",
                table: "Gardens",
                column: "Plantid",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steads_Plants_Plantid",
                table: "Steads",
                column: "Plantid",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
