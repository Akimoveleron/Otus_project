using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "plant",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        plant_name = table.Column<string>(type: "character varying", nullable: true),
            //        temp_min = table.Column<int>(type: "integer", nullable: true),
            //        temp_max = table.Column<int>(type: "integer", nullable: true),
            //        soil_moisture_min = table.Column<int>(type: "integer", nullable: true),
            //        soil_moisture_max = table.Column<int>(type: "integer", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("plant_pkey", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "r$precipitation",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false),
            //        precipitation = table.Column<string>(type: "character varying", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("precipitation_pkey", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "region",
            //    columns: table => new
            //    {
            //        region_code_id = table.Column<int>(type: "integer", nullable: false),
            //        region_name = table.Column<string>(type: "character varying", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("region_pkey", x => x.region_code_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Role",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Role", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "r$reestr_object",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        region_code_id = table.Column<int>(type: "integer", nullable: true),
            //        object_name = table.Column<string>(type: "character varying", nullable: true),
            //        accuweather_id = table.Column<int>(type: "integer", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("r$reestr_object_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_r$reestr_object_region_region_code_id",
            //            column: x => x.region_code_id,
            //            principalTable: "region",
            //            principalColumn: "region_code_id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "users",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        first_name = table.Column<string>(type: "character varying", nullable: true),
            //        second_name = table.Column<string>(type: "character varying", nullable: true),
            //        last_name = table.Column<string>(type: "character varying", nullable: true),
            //        region_code_id = table.Column<int>(type: "integer", nullable: true),
            //        Password = table.Column<string>(type: "text", nullable: true),
            //        Login = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
            //        email = table.Column<string>(type: "character varying", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
            //        phone_number = table.Column<string>(type: "character varying", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("users_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "users_region_code_fkey",
            //            column: x => x.region_code_id,
            //            principalTable: "region",
            //            principalColumn: "region_code_id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "weather_calendar",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        region_code_id = table.Column<int>(type: "integer", nullable: true),
            //        object_id = table.Column<int>(type: "integer", nullable: true),
            //        date_tame = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        precipitation_id = table.Column<int>(type: "integer", nullable: true),
            //        temperatura_max = table.Column<int>(type: "integer", nullable: true),
            //        temperatura_min = table.Column<int>(type: "integer", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("weather_calendar_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "weather_calendar_object_id_fkey",
            //            column: x => x.object_id,
            //            principalTable: "r$reestr_object",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "weather_calendar_precipitation_id_fkey",
            //            column: x => x.precipitation_id,
            //            principalTable: "r$precipitation",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "weather_calendar_region_code_fkey",
            //            column: x => x.region_code_id,
            //            principalTable: "region",
            //            principalColumn: "region_code_id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "stead",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        region_code_id = table.Column<int>(type: "integer", nullable: true),
            //        object_id = table.Column<int>(type: "integer", nullable: true),
            //        user_id = table.Column<int>(type: "integer", nullable: true),
            //        plant_id = table.Column<int>(type: "integer", nullable: true),
            //        start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("stead_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "stead_object_id_fkey",
            //            column: x => x.object_id,
            //            principalTable: "r$reestr_object",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "stead_plant_id_fkey",
            //            column: x => x.plant_id,
            //            principalTable: "plant",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "stead_region_code_fkey",
            //            column: x => x.region_code_id,
            //            principalTable: "region",
            //            principalColumn: "region_code_id");
            //        table.ForeignKey(
            //            name: "stead_user_id_fkey",
            //            column: x => x.user_id,
            //            principalTable: "users",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRole",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "integer", nullable: false),
            //        RoleId = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_UserRole_Role_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Role",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserRole_users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "users",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserToken",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        UserId = table.Column<int>(type: "integer", nullable: false),
            //        Value = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserToken", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserToken_users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "users",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_r$reestr_object_region_code_id",
            //    table: "r$reestr_object",
            //    column: "region_code_id");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "Role",
            //    column: "NormalizedName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_stead_object_id",
            //    table: "stead",
            //    column: "object_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_stead_plant_id",
            //    table: "stead",
            //    column: "plant_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_stead_region_code_id",
            //    table: "stead",
            //    column: "region_code_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_stead_user_id",
            //    table: "stead",
            //    column: "user_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRole_RoleId",
            //    table: "UserRole",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "users",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "IX_users_region_code_id",
            //    table: "users",
            //    column: "region_code_id");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "users",
            //    column: "NormalizedUserName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserToken_UserId",
            //    table: "UserToken",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_weather_calendar_object_id",
            //    table: "weather_calendar",
            //    column: "object_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_weather_calendar_precipitation_id",
            //    table: "weather_calendar",
            //    column: "precipitation_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_weather_calendar_region_code_id",
            //    table: "weather_calendar",
            //    column: "region_code_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "stead");

            //migrationBuilder.DropTable(
            //    name: "UserRole");

            //migrationBuilder.DropTable(
            //    name: "UserToken");

            //migrationBuilder.DropTable(
            //    name: "weather_calendar");

            //migrationBuilder.DropTable(
            //    name: "plant");

            //migrationBuilder.DropTable(
            //    name: "Role");

            //migrationBuilder.DropTable(
            //    name: "users");

            //migrationBuilder.DropTable(
            //    name: "r$reestr_object");

            //migrationBuilder.DropTable(
            //    name: "r$precipitation");

            //migrationBuilder.DropTable(
            //    name: "region");
        }
    }
}
