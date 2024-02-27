using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BigFix001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Gardens_Plants_PlantId",
            //    table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_RReestrObjects_Regions_RegionCodeId",
                table: "RReestrObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_RegionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherCalendars_Regions_RegionCodeId",
                table: "WeatherCalendars");

            migrationBuilder.DropTable(
                name: "Steads");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_WeatherCalendars_RegionCodeId",
                table: "WeatherCalendars");

            migrationBuilder.DropIndex(
                name: "IX_Users_RegionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RReestrObjects_RegionCodeId",
                table: "RReestrObjects");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_PlantId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "RegionCodeId",
                table: "WeatherCalendars");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegionCodeId",
                table: "RReestrObjects");

            migrationBuilder.DropColumn(
                name: "DateHarvesting",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "DateHoeing",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "DateLoosening",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "DatePlanting",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "DateWatering",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "DateWeeding",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "ObjectName",
                table: "RReestrObjects",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gardens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ObjectId",
                table: "Gardens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "RPlants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NumberMonthsForPlanting = table.Column<int[]>(type: "integer[]", nullable: false),
                    MaxTemperaturaForPlanting = table.Column<int>(type: "integer", nullable: false),
                    MinTemperaturaForPlanting = table.Column<int>(type: "integer", nullable: false),
                    FirstWateringAfterPlanting = table.Column<int>(type: "integer", nullable: true),
                    WateringPeriod = table.Column<int>(type: "integer", nullable: false),
                    HoeingAfterPlanting = table.Column<int[]>(type: "integer[]", nullable: true),
                    LooseningPeriod = table.Column<int>(type: "integer", nullable: true),
                    WeedingPeriod = table.Column<int>(type: "integer", nullable: true),
                    HarvestingAfterPlanting = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPlants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGardens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GardenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGardens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGardens_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantsInGarden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GardenId = table.Column<int>(type: "integer", nullable: false),
                    RPlantId = table.Column<int>(type: "integer", nullable: false),
                    DatePlanting = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateWatering = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateHoeing = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateLoosening = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateWeeding = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateHarvesting = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NotificationOnTelegram = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsInGarden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantsInGarden_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantsInGarden_RPlants_RPlantId",
                        column: x => x.RPlantId,
                        principalTable: "RPlants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantsInGarden_GardenId",
                table: "PlantsInGarden",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantsInGarden_RPlantId",
                table: "PlantsInGarden",
                column: "RPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGardens_GardenId",
                table: "UserGardens",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGardens_UserId",
                table: "UserGardens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantsInGarden");

            migrationBuilder.DropTable(
                name: "UserGardens");

            migrationBuilder.DropTable(
                name: "RPlants");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RReestrObjects",
                newName: "ObjectName");

            migrationBuilder.AddColumn<int>(
                name: "RegionCodeId",
                table: "WeatherCalendars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionCodeId",
                table: "RReestrObjects",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateHarvesting",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateHoeing",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLoosening",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePlanting",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWatering",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateWeeding",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Gardens",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "Gardens",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstWateringAfterPlanting = table.Column<int>(type: "integer", nullable: true),
                    HarvestingAfterPlanting = table.Column<int>(type: "integer", nullable: true),
                    HoeingAfterPlanting = table.Column<int[]>(type: "integer[]", nullable: true),
                    LooseningPeriod = table.Column<int>(type: "integer", nullable: true),
                    MinTemperaturaForPlanting = table.Column<int>(type: "integer", nullable: true),
                    NumberMonthsForPlanting = table.Column<int[]>(type: "integer[]", nullable: true),
                    PlantName = table.Column<string>(type: "text", nullable: true),
                    WateringPeriod = table.Column<int>(type: "integer", nullable: true),
                    WeedingPeriod = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionCodeId = table.Column<int>(type: "integer", nullable: false),
                    RegionName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectId = table.Column<int>(type: "integer", nullable: true),
                    PlantId = table.Column<int>(type: "integer", nullable: true),
                    RegionCodeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steads_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Steads_RReestrObjects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "RReestrObjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Steads_Regions_RegionCodeId",
                        column: x => x.RegionCodeId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Steads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCalendars_RegionCodeId",
                table: "WeatherCalendars",
                column: "RegionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegionId",
                table: "Users",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RReestrObjects_RegionCodeId",
                table: "RReestrObjects",
                column: "RegionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_PlantId",
                table: "Gardens",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_ObjectId",
                table: "Steads",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_PlantId",
                table: "Steads",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_RegionCodeId",
                table: "Steads",
                column: "RegionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_UserId",
                table: "Steads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Plants_PlantId",
                table: "Gardens",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RReestrObjects_Regions_RegionCodeId",
                table: "RReestrObjects",
                column: "RegionCodeId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_RegionId",
                table: "Users",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherCalendars_Regions_RegionCodeId",
                table: "WeatherCalendars",
                column: "RegionCodeId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
