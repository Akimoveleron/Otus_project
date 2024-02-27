using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccuMicroService.Migrations
{
    public partial class _2Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherCalendars_RPrecipitations_PrecipitationId",
                table: "WeatherCalendars");

            migrationBuilder.DropIndex(
                name: "IX_WeatherCalendars_PrecipitationId",
                table: "WeatherCalendars");

            migrationBuilder.DropColumn(
                name: "PrecipitationId",
                table: "WeatherCalendars");

            migrationBuilder.AddColumn<string>(
                name: "Precipitation",
                table: "WeatherCalendars",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precipitation",
                table: "WeatherCalendars");

            migrationBuilder.AddColumn<int>(
                name: "PrecipitationId",
                table: "WeatherCalendars",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCalendars_PrecipitationId",
                table: "WeatherCalendars",
                column: "PrecipitationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherCalendars_RPrecipitations_PrecipitationId",
                table: "WeatherCalendars",
                column: "PrecipitationId",
                principalTable: "RPrecipitations",
                principalColumn: "Id");
        }
    }
}
