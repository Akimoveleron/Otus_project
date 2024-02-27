using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public partial class GardenCalendaryContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, UserToken>, IGardenCalendaryContext

{
    private IConfiguration _configuration;
    public GardenCalendaryContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public GardenCalendaryContext(DbContextOptions<GardenCalendaryContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Garden> Gardens { get; set; }

    public virtual DbSet<PlantInGarden> PlantsInGarden { get; set; }

    public virtual DbSet<RPlant> RPlants { get; set; }

    public virtual DbSet<RReestrObject> RReestrObjects { get; set; }

    public virtual DbSet<UserGarden> UserGardens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:PostgreSQL"]);

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<User>().Ignore(c => c.AccessFailedCount)
                         .Ignore(c => c.LockoutEnabled)
                         .Ignore(c => c.TwoFactorEnabled)
                         .Ignore(c => c.EmailConfirmed)
                         .Ignore(c => c.LockoutEnd)
                         .Ignore(c => c.NormalizedEmail)
                         .Ignore(c => c.NormalizedUserName)
                         .Ignore(c => c.PasswordHash)
                         .Ignore(c => c.PhoneNumberConfirmed)
                         .Ignore(c => c.ConcurrencyStamp)
                         .Ignore(c => c.SecurityStamp);

        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.UserName).HasColumnName("UserName");
        });

        builder.Entity<Role>().Ignore(c => c.ConcurrencyStamp);

        builder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
        });

        builder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.ToTable("UserRoles");
            entity.HasKey(key => new { key.UserId, key.RoleId });
        });

        builder.Entity<UserToken>(entity =>
        {
            entity.ToTable("UserTokens");
            entity.HasKey(key => key.Id);
        });

        builder.Entity<UserToken>().Ignore(c => c.LoginProvider)
          .Ignore(c => c.Name);

        builder.Ignore<IdentityUserClaim<int>>();
        builder.Ignore<IdentityRoleClaim<int>>();
        builder.Ignore<IdentityUserLogin<int>>();
    }

}
