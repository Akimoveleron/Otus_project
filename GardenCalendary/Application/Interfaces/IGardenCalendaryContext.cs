using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IGardenCalendaryContext
    {
        public DbSet<Garden> Gardens { get; set; }

        public DbSet<PlantInGarden> PlantsInGarden { get; set; }

        public DbSet<RPlant> RPlants { get; set; }

        public DbSet<RReestrObject> RReestrObjects { get; set; }

        public DbSet<UserGarden> UserGardens { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<IdentityUserRole<int>> UserRoles { get; set; }

        public int SaveChanges();
    }
}
