using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_plant_to_garden",
                table: "garden");

            migrationBuilder.DropForeignKey(
                name: "FK_r$reestr_object_region_region_code_id",
                table: "r$reestr_object");

            migrationBuilder.DropForeignKey(
                name: "stead_object_id_fkey",
                table: "stead");

            migrationBuilder.DropForeignKey(
                name: "stead_plantid_fkey",
                table: "stead");

            migrationBuilder.DropForeignKey(
                name: "stead_region_code_fkey",
                table: "stead");

            migrationBuilder.DropForeignKey(
                name: "stead_user_id_fkey",
                table: "stead");

            migrationBuilder.DropForeignKey(
                name: "users_region_code_fkey",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_users_UserId",
                table: "UserToken");

            migrationBuilder.DropForeignKey(
                name: "weather_calendar_object_id_fkey",
                table: "weather_calendar");

            migrationBuilder.DropForeignKey(
                name: "weather_calendar_precipitation_id_fkey",
                table: "weather_calendar");

            migrationBuilder.DropForeignKey(
                name: "weather_calendar_region_code_fkey",
                table: "weather_calendar");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "users_pkey",
                table: "users");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "weather_calendar_pkey",
                table: "weather_calendar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToken",
                table: "UserToken");

            migrationBuilder.DropPrimaryKey(
                name: "stead_pkey",
                table: "stead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "region_pkey",
                table: "region");

            migrationBuilder.DropPrimaryKey(
                name: "r$reestr_object_pkey",
                table: "r$reestr_object");

            migrationBuilder.DropPrimaryKey(
                name: "precipitation_pkey",
                table: "r$precipitation");

            migrationBuilder.DropPrimaryKey(
                name: "plant_pkey",
                table: "plant");

            migrationBuilder.DropPrimaryKey(
                name: "garden_pkey",
                table: "garden");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "weather_calendar",
                newName: "WeatherCalendars");

            migrationBuilder.RenameTable(
                name: "UserToken",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "stead",
                newName: "Steads");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "region",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "r$reestr_object",
                newName: "RReestrObjects");

            migrationBuilder.RenameTable(
                name: "r$precipitation",
                newName: "RPrecipitations");

            migrationBuilder.RenameTable(
                name: "plant",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "garden",
                newName: "Gardens");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "Users",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "region_code_id",
                table: "Users",
                newName: "RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_users_region_code_id",
                table: "Users",
                newName: "IX_Users_RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WeatherCalendars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "temperatura_min",
                table: "WeatherCalendars",
                newName: "TemperaturaMin");

            migrationBuilder.RenameColumn(
                name: "temperatura_max",
                table: "WeatherCalendars",
                newName: "TemperaturaMax");

            migrationBuilder.RenameColumn(
                name: "region_code_id",
                table: "WeatherCalendars",
                newName: "RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "precipitation_id",
                table: "WeatherCalendars",
                newName: "PrecipitationId");

            migrationBuilder.RenameColumn(
                name: "object_id",
                table: "WeatherCalendars",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "date_tame",
                table: "WeatherCalendars",
                newName: "DateTame");

            migrationBuilder.RenameIndex(
                name: "IX_weather_calendar_region_code_id",
                table: "WeatherCalendars",
                newName: "IX_WeatherCalendars_RegionCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_weather_calendar_precipitation_id",
                table: "WeatherCalendars",
                newName: "IX_WeatherCalendars_PrecipitationId");

            migrationBuilder.RenameIndex(
                name: "IX_weather_calendar_object_id",
                table: "WeatherCalendars",
                newName: "IX_WeatherCalendars_ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserToken_UserId",
                table: "UserTokens",
                newName: "IX_UserTokens_UserId");

            migrationBuilder.RenameColumn(
                name: "plantid",
                table: "Steads",
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Steads",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Steads",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Steads",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "region_code_id",
                table: "Steads",
                newName: "RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "object_id",
                table: "Steads",
                newName: "ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_stead_user_id",
                table: "Steads",
                newName: "IX_Steads_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_stead_region_code_id",
                table: "Steads",
                newName: "IX_Steads_RegionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_PlantId",
                table: "Steads",
                column: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_stead_object_id",
                table: "Steads",
                newName: "IX_Steads_ObjectId");

            migrationBuilder.RenameColumn(
                name: "region_name",
                table: "Regions",
                newName: "RegionName");

            migrationBuilder.RenameColumn(
                name: "region_code_id",
                table: "Regions",
                newName: "RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RReestrObjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "region_code_id",
                table: "RReestrObjects",
                newName: "RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "object_name",
                table: "RReestrObjects",
                newName: "ObjectName");

            migrationBuilder.RenameColumn(
                name: "accuweather_id",
                table: "RReestrObjects",
                newName: "AccuweatherId");

            migrationBuilder.RenameIndex(
                name: "IX_r$reestr_object_region_code_id",
                table: "RReestrObjects",
                newName: "IX_RReestrObjects_RegionCodeId");

            migrationBuilder.RenameColumn(
                name: "precipitation",
                table: "RPrecipitations",
                newName: "Precipitation");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RPrecipitations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "plantname",
                table: "Gardens",
                newName: "Plantname");

            migrationBuilder.RenameColumn(
                name: "plantid",
                table: "Gardens",
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "dateweeding",
                table: "Gardens",
                newName: "Dateweeding");

            migrationBuilder.RenameColumn(
                name: "datewatering",
                table: "Gardens",
                newName: "Datewatering");

            migrationBuilder.RenameColumn(
                name: "dateplantingt",
                table: "Gardens",
                newName: "Dateplantingt");

            migrationBuilder.RenameColumn(
                name: "dateloosening",
                table: "Gardens",
                newName: "Dateloosening");

            migrationBuilder.RenameColumn(
                name: "datehoeing",
                table: "Gardens",
                newName: "Datehoeing");

            migrationBuilder.RenameColumn(
                name: "dateharvesting",
                table: "Gardens",
                newName: "Dateharvesting");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Gardens",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_PlantId",
                table: "Gardens",
                column: "PlantId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "Regions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Regions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectName",
                table: "RReestrObjects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Precipitation",
                table: "RPrecipitations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RPrecipitations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateweeding",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datewatering",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateplantingt",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateloosening",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datehoeing",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateharvesting",
                table: "Gardens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherCalendars",
                table: "WeatherCalendars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steads",
                table: "Steads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RReestrObjects",
                table: "RReestrObjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RPrecipitations",
                table: "RPrecipitations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId",
                table: "UserRoles",
                column: "UsersId");

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
                name: "FK_Steads_Plants_PlantId",
                table: "Steads",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steads_RReestrObjects_ObjectId",
                table: "Steads",
                column: "ObjectId",
                principalTable: "RReestrObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steads_Regions_RegionCodeId",
                table: "Steads",
                column: "RegionCodeId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steads_Users_UserId",
                table: "Steads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Regions_RegionCodeId",
                table: "Users",
                column: "RegionCodeId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherCalendars_RPrecipitations_PrecipitationId",
                table: "WeatherCalendars",
                column: "PrecipitationId",
                principalTable: "RPrecipitations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherCalendars_RReestrObjects_ObjectId",
                table: "WeatherCalendars",
                column: "ObjectId",
                principalTable: "RReestrObjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherCalendars_Regions_RegionCodeId",
                table: "WeatherCalendars",
                column: "RegionCodeId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Plants_PlantId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_RReestrObjects_Regions_RegionCodeId",
                table: "RReestrObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Steads_Plants_PlantId",
                table: "Steads");

            migrationBuilder.DropForeignKey(
                name: "FK_Steads_RReestrObjects_ObjectId",
                table: "Steads");

            migrationBuilder.DropForeignKey(
                name: "FK_Steads_Regions_RegionCodeId",
                table: "Steads");

            migrationBuilder.DropForeignKey(
                name: "FK_Steads_Users_UserId",
                table: "Steads");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_RegionCodeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherCalendars_RPrecipitations_PrecipitationId",
                table: "WeatherCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherCalendars_RReestrObjects_ObjectId",
                table: "WeatherCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherCalendars_Regions_RegionCodeId",
                table: "WeatherCalendars");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherCalendars",
                table: "WeatherCalendars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steads",
                table: "Steads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RReestrObjects",
                table: "RReestrObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RPrecipitations",
                table: "RPrecipitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "WeatherCalendars",
                newName: "weather_calendar");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserToken");

            migrationBuilder.RenameTable(
                name: "Steads",
                newName: "stead");

            migrationBuilder.RenameTable(
                name: "RReestrObjects",
                newName: "r$reestr_object");

            migrationBuilder.RenameTable(
                name: "RPrecipitations",
                newName: "r$precipitation");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "region");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "plant");

            migrationBuilder.RenameTable(
                name: "Gardens",
                newName: "garden");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "users",
                newName: "second_name");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "users",
                newName: "region_code_id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RegionCodeId",
                table: "users",
                newName: "IX_users_region_code_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "weather_calendar",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TemperaturaMin",
                table: "weather_calendar",
                newName: "temperatura_min");

            migrationBuilder.RenameColumn(
                name: "TemperaturaMax",
                table: "weather_calendar",
                newName: "temperatura_max");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "weather_calendar",
                newName: "region_code_id");

            migrationBuilder.RenameColumn(
                name: "PrecipitationId",
                table: "weather_calendar",
                newName: "precipitation_id");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "weather_calendar",
                newName: "object_id");

            migrationBuilder.RenameColumn(
                name: "DateTame",
                table: "weather_calendar",
                newName: "date_tame");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherCalendars_RegionCodeId",
                table: "weather_calendar",
                newName: "IX_weather_calendar_region_code_id");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherCalendars_PrecipitationId",
                table: "weather_calendar",
                newName: "IX_weather_calendar_precipitation_id");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherCalendars_ObjectId",
                table: "weather_calendar",
                newName: "IX_weather_calendar_object_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserTokens_UserId",
                table: "UserToken",
                newName: "IX_UserToken_UserId");

            migrationBuilder.RenameColumn(
                name: "Plantid",
                table: "stead", 
                newName: "PlantId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "stead",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "stead",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "stead",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "stead",
                newName: "region_code_id");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "stead",
                newName: "object_id");

            migrationBuilder.RenameIndex(
                name: "IX_Steads_UserId",
                table: "stead",
                newName: "IX_stead_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Steads_RegionCodeId",
                table: "stead",
                newName: "IX_stead_region_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_Steads_PlantId",
                table: "Steads",
                column: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Steads_ObjectId",
                table: "stead",
                newName: "IX_stead_object_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "r$reestr_object",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "r$reestr_object",
                newName: "region_code_id");

            migrationBuilder.RenameColumn(
                name: "ObjectName",
                table: "r$reestr_object",
                newName: "object_name");

            migrationBuilder.RenameColumn(
                name: "AccuweatherId",
                table: "r$reestr_object",
                newName: "accuweather_id");

            migrationBuilder.RenameIndex(
                name: "IX_RReestrObjects_RegionCodeId",
                table: "r$reestr_object",
                newName: "IX_r$reestr_object_region_code_id");

            migrationBuilder.RenameColumn(
                name: "Precipitation",
                table: "r$precipitation",
                newName: "precipitation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "r$precipitation",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegionName",
                table: "region",
                newName: "region_name");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "region",
                newName: "region_code_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "plant",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Plantname",
                table: "garden",
                newName: "plantname");

            migrationBuilder.RenameColumn(
                name: "Plantid",
                table: "garden",
                newName: "plantid");

            migrationBuilder.RenameColumn(
                name: "Dateweeding",
                table: "garden",
                newName: "dateweeding");

            migrationBuilder.RenameColumn(
                name: "Datewatering",
                table: "garden",
                newName: "datewatering");

            migrationBuilder.RenameColumn(
                name: "Dateplantingt",
                table: "garden",
                newName: "dateplantingt");

            migrationBuilder.RenameColumn(
                name: "Dateloosening",
                table: "garden",
                newName: "dateloosening");

            migrationBuilder.RenameColumn(
                name: "Datehoeing",
                table: "garden",
                newName: "datehoeing");

            migrationBuilder.RenameColumn(
                name: "Dateharvesting",
                table: "garden",
                newName: "dateharvesting");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "garden",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Gardens_Plantid",
                table: "garden",
                newName: "IX_garden_plantid");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "second_name",
                table: "users",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "users",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "users",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "users",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "object_name",
                table: "r$reestr_object",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "precipitation",
                table: "r$precipitation",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "r$precipitation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Role",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "region_name",
                table: "region",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateweeding",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datewatering",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateplantingt",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateloosening",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datehoeing",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateharvesting",
                table: "garden",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "users_pkey",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "weather_calendar_pkey",
                table: "weather_calendar",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToken",
                table: "UserToken",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "stead_pkey",
                table: "stead",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "r$reestr_object_pkey",
                table: "r$reestr_object",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "precipitation_pkey",
                table: "r$precipitation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "region_pkey",
                table: "region",
                column: "region_code_id");

            migrationBuilder.AddPrimaryKey(
                name: "plant_pkey",
                table: "plant",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "garden_pkey",
                table: "garden",
                column: "id");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "fk_plant_to_garden",
                table: "garden",
                column: "plantid",
                principalTable: "plant",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_r$reestr_object_region_region_code_id",
                table: "r$reestr_object",
                column: "region_code_id",
                principalTable: "region",
                principalColumn: "region_code_id");

            migrationBuilder.AddForeignKey(
                name: "stead_object_id_fkey",
                table: "stead",
                column: "object_id",
                principalTable: "r$reestr_object",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "stead_plantid_fkey",
                table: "stead",
                column: "plantid",
                principalTable: "plant",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "stead_region_code_fkey",
                table: "stead",
                column: "region_code_id",
                principalTable: "region",
                principalColumn: "region_code_id");

            migrationBuilder.AddForeignKey(
                name: "stead_user_id_fkey",
                table: "stead",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "users_region_code_fkey",
                table: "users",
                column: "region_code_id",
                principalTable: "region",
                principalColumn: "region_code_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_users_UserId",
                table: "UserToken",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "weather_calendar_object_id_fkey",
                table: "weather_calendar",
                column: "object_id",
                principalTable: "r$reestr_object",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "weather_calendar_precipitation_id_fkey",
                table: "weather_calendar",
                column: "precipitation_id",
                principalTable: "r$precipitation",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "weather_calendar_region_code_fkey",
                table: "weather_calendar",
                column: "region_code_id",
                principalTable: "region",
                principalColumn: "region_code_id");
        }
    }
}
