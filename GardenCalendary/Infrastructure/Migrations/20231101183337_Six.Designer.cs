﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GardenCalendaryContext))]
    [Migration("20231101183337_Six")]
    partial class Six
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateHarvesting")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateHoeing")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLoosening")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DatePlanting")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateWatering")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateWeeding")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PlantId")
                        .HasColumnType("integer");

                    b.Property<string>("PlantName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("Domain.Entities.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstWateringAfterPlanting")
                        .HasColumnType("integer");

                    b.Property<int?>("HarvestingAfterPlanting")
                        .HasColumnType("integer");

                    b.Property<int[]>("HoeingAfterPlanting")
                        .HasColumnType("integer[]");

                    b.Property<int?>("LooseningPeriod")
                        .HasColumnType("integer");

                    b.Property<int?>("MinTemperaturaForPlanting")
                        .HasColumnType("integer");

                    b.Property<int[]>("NumberMonthsForPlanting")
                        .HasColumnType("integer[]");

                    b.Property<string>("PlantName")
                        .HasColumnType("text");

                    b.Property<int?>("WateringPeriod")
                        .HasColumnType("integer");

                    b.Property<int?>("WeedingPeriod")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Domain.Entities.RPrecipitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Precipitation")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RPrecipitations");
                });

            modelBuilder.Entity("Domain.Entities.RReestrObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccuweatherId")
                        .HasColumnType("integer");

                    b.Property<string>("ObjectName")
                        .HasColumnType("text");

                    b.Property<int?>("RegionCodeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RegionCodeId");

                    b.ToTable("RReestrObjects");
                });

            modelBuilder.Entity("Domain.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RegionCodeId")
                        .HasColumnType("integer");

                    b.Property<string>("RegionName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Stead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ObjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlantId")
                        .HasColumnType("integer");

                    b.Property<int?>("RegionCodeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("PlantId");

                    b.HasIndex("RegionCodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Steads");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId1")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.WeatherCalendarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateTame")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ObjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("PrecipitationId")
                        .HasColumnType("integer");

                    b.Property<int?>("RegionCodeId")
                        .HasColumnType("integer");

                    b.Property<int?>("TemperaturaMax")
                        .HasColumnType("integer");

                    b.Property<int?>("TemperaturaMin")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("PrecipitationId");

                    b.HasIndex("RegionCodeId");

                    b.ToTable("WeatherCalendars");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Domain.Entities.Garden", b =>
                {
                    b.HasOne("Domain.Entities.Plant", "Plant")
                        .WithMany("Gardens")
                        .HasForeignKey("PlantId");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Domain.Entities.RReestrObject", b =>
                {
                    b.HasOne("Domain.Entities.Region", "RegionCode")
                        .WithMany("RReestrObjects")
                        .HasForeignKey("RegionCodeId");

                    b.Navigation("RegionCode");
                });

            modelBuilder.Entity("Domain.Entities.Stead", b =>
                {
                    b.HasOne("Domain.Entities.RReestrObject", "Object")
                        .WithMany("Steads")
                        .HasForeignKey("ObjectId");

                    b.HasOne("Domain.Entities.Plant", "Plant")
                        .WithMany("Steads")
                        .HasForeignKey("PlantId");

                    b.HasOne("Domain.Entities.Region", "RegionCode")
                        .WithMany("Steads")
                        .HasForeignKey("RegionCodeId");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Steads")
                        .HasForeignKey("UserId");

                    b.Navigation("Object");

                    b.Navigation("Plant");

                    b.Navigation("RegionCode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Region", "Region")
                        .WithMany("Users")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.UserToken", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.WeatherCalendarModel", b =>
                {
                    b.HasOne("Domain.Entities.RReestrObject", "Object")
                        .WithMany("WeatherCalendars")
                        .HasForeignKey("ObjectId");

                    b.HasOne("Domain.Entities.RPrecipitation", "Precipitation")
                        .WithMany("WeatherCalendars")
                        .HasForeignKey("PrecipitationId");

                    b.HasOne("Domain.Entities.Region", "RegionCode")
                        .WithMany("WeatherCalendars")
                        .HasForeignKey("RegionCodeId");

                    b.Navigation("Object");

                    b.Navigation("Precipitation");

                    b.Navigation("RegionCode");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Plant", b =>
                {
                    b.Navigation("Gardens");

                    b.Navigation("Steads");
                });

            modelBuilder.Entity("Domain.Entities.RPrecipitation", b =>
                {
                    b.Navigation("WeatherCalendars");
                });

            modelBuilder.Entity("Domain.Entities.RReestrObject", b =>
                {
                    b.Navigation("Steads");

                    b.Navigation("WeatherCalendars");
                });

            modelBuilder.Entity("Domain.Entities.Region", b =>
                {
                    b.Navigation("RReestrObjects");

                    b.Navigation("Steads");

                    b.Navigation("Users");

                    b.Navigation("WeatherCalendars");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Steads");

                    b.Navigation("UserTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
