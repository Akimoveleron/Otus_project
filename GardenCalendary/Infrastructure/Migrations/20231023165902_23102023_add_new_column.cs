using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _23102023_add_new_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "stead_plant_id_fkey",
            //    table: "stead");

            //migrationBuilder.RenameColumn(
            //    name: "plant_id",
            //    table: "stead",
            //    newName: "plantid");

            //migrationBuilder.RenameIndex(
            //    name: "IX_stead_plant_id",
            //    table: "stead",
            //    newName: "IX_stead_plantid");

            //migrationBuilder.RenameColumn(
            //    name: "plant_name",
            //    table: "plant",
            //    newName: "PlantName");

            //migrationBuilder.RenameColumn(
            //    name: "temp_min",
            //    table: "plant",
            //    newName: "WeedingPeriod");

            //migrationBuilder.RenameColumn(
            //    name: "temp_max",
            //    table: "plant",
            //    newName: "WateringPeriod");

            //migrationBuilder.RenameColumn(
            //    name: "soil_moisture_min",
            //    table: "plant",
            //    newName: "MinTemperaturaForPlanting");

            //migrationBuilder.RenameColumn(
            //    name: "soil_moisture_max",
            //    table: "plant",
            //    newName: "LooseningPeriod");

            //migrationBuilder.AddColumn<string>(
            //    name: "LoginProvider",
            //    table: "UserToken",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Name",
            //    table: "UserToken",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "AccessFailedCount",
            //    table: "users",
            //    type: "integer",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "users",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "EmailConfirmed",
            //    table: "users",
            //    type: "boolean",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "LockoutEnabled",
            //    table: "users",
            //    type: "boolean",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<DateTimeOffset>(
            //    name: "LockoutEnd",
            //    table: "users",
            //    type: "timestamp with time zone",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PasswordHash",
            //    table: "users",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "PhoneNumberConfirmed",
            //    table: "users",
            //    type: "boolean",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "SecurityStamp",
            //    table: "users",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "TwoFactorEnabled",
            //    table: "users",
            //    type: "boolean",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "users",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "plantid",
            //    table: "stead",
            //    type: "uuid",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "integer",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "Role",
            //    type: "text",
            //    nullable: true);

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "id",
            //    table: "plant",
            //    type: "uuid",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "integer")
            //    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            //migrationBuilder.AlterColumn<string>(
            //    name: "PlantName",
            //    table: "plant",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "character varying",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "FirstWateringAfterPlanting",
            //    table: "plant",
            //    type: "integer",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "HarvestingAfterPlanting",
            //    table: "plant",
            //    type: "integer",
            //    nullable: true);

            //migrationBuilder.AddColumn<int[]>(
            //    name: "HoeingAfterPlanting",
            //    table: "plant",
            //    type: "integer[]",
            //    nullable: true);

            //migrationBuilder.AddColumn<int[]>(
            //    name: "NumberMonthsForPlanting",
            //    table: "plant",
            //    type: "integer[]",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "garden",
            //    columns: table => new
            //    {
            //        id = table.Column<Guid>(type: "uuid", nullable: false),
            //        plantname = table.Column<string>(type: "text", nullable: true),
            //        plantid = table.Column<Guid>(type: "uuid", nullable: true),
            //        dateplantingt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        datewatering = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        datehoeing = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        dateloosening = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        dateweeding = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //        dateharvesting = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("garden_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "fk_plant_to_garden",
            //            column: x => x.plantid,
            //            principalTable: "plant",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_garden_plantid",
            //    table: "garden",
            //    column: "plantid");

            //migrationBuilder.AddForeignKey(
            //    name: "stead_plantid_fkey",
            //    table: "stead",
            //    column: "plantid",
            //    principalTable: "plant",
            //    principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "stead_plantid_fkey",
            //    table: "stead");

            //migrationBuilder.DropTable(
            //    name: "garden");

            //migrationBuilder.DropColumn(
            //    name: "LoginProvider",
            //    table: "UserToken");

            //migrationBuilder.DropColumn(
            //    name: "Name",
            //    table: "UserToken");

            //migrationBuilder.DropColumn(
            //    name: "AccessFailedCount",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "ConcurrencyStamp",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "EmailConfirmed",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "LockoutEnabled",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "LockoutEnd",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "PasswordHash",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "PhoneNumberConfirmed",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "SecurityStamp",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "TwoFactorEnabled",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "users");

            //migrationBuilder.DropColumn(
            //    name: "ConcurrencyStamp",
            //    table: "Role");

            //migrationBuilder.DropColumn(
            //    name: "FirstWateringAfterPlanting",
            //    table: "plant");

            //migrationBuilder.DropColumn(
            //    name: "HarvestingAfterPlanting",
            //    table: "plant");

            //migrationBuilder.DropColumn(
            //    name: "HoeingAfterPlanting",
            //    table: "plant");

            //migrationBuilder.DropColumn(
            //    name: "NumberMonthsForPlanting",
            //    table: "plant");

            //migrationBuilder.RenameColumn(
            //    name: "plantid",
            //    table: "stead",
            //    newName: "plant_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_stead_plantid",
            //    table: "stead",
            //    newName: "IX_stead_plant_id");

            //migrationBuilder.RenameColumn(
            //    name: "PlantName",
            //    table: "plant",
            //    newName: "plant_name");

            //migrationBuilder.RenameColumn(
            //    name: "WeedingPeriod",
            //    table: "plant",
            //    newName: "temp_min");

            //migrationBuilder.RenameColumn(
            //    name: "WateringPeriod",
            //    table: "plant",
            //    newName: "temp_max");

            //migrationBuilder.RenameColumn(
            //    name: "MinTemperaturaForPlanting",
            //    table: "plant",
            //    newName: "soil_moisture_min");

            //migrationBuilder.RenameColumn(
            //    name: "LooseningPeriod",
            //    table: "plant",
            //    newName: "soil_moisture_max");

            //migrationBuilder.AlterColumn<int>(
            //    name: "plant_id",
            //    table: "stead",
            //    type: "integer",
            //    nullable: true,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "id",
            //    table: "plant",
            //    type: "integer",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid")
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            //migrationBuilder.AlterColumn<string>(
            //    name: "plant_name",
            //    table: "plant",
            //    type: "character varying",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text",
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "stead_plant_id_fkey",
            //    table: "stead",
            //    column: "plant_id",
            //    principalTable: "plant",
            //    principalColumn: "id");
        }
    }
}
