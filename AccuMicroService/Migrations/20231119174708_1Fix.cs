using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccuMicroService.Migrations
{
    public partial class _1Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTame",
                table: "WeatherCalendars",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "WeatherCalendars",
                newName: "DateTame");
        }
    }
}
