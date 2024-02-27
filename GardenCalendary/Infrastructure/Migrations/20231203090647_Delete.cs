using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherCalendars");

            migrationBuilder.DropTable(
                name: "RPrecipitations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RPrecipitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Precipitation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPrecipitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectId = table.Column<int>(type: "integer", nullable: true),
                    PrecipitationId = table.Column<int>(type: "integer", nullable: true),
                    DateTame = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TemperaturaMax = table.Column<int>(type: "integer", nullable: true),
                    TemperaturaMin = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherCalendars_RPrecipitations_PrecipitationId",
                        column: x => x.PrecipitationId,
                        principalTable: "RPrecipitations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherCalendars_RReestrObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "RReestrObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCalendars_ObjectId",
                table: "WeatherCalendars",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCalendars_PrecipitationId",
                table: "WeatherCalendars",
                column: "PrecipitationId");
        }
    }
}
