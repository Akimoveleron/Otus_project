using GardeningTipsService.Entities;
using GardeningTipsService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GardeningTipsService;

public partial class GardenTipsContext : DbContext
{
    private IConfiguration _configuration;
    public GardenTipsContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Garden> Gardens { get; set; }

    public virtual DbSet<PlantInGarden> PlantsInGarden { get; set; }

    public virtual DbSet<RPlant> RPlants { get; set; }

    public virtual DbSet<RReestrObject> RReestrObjects { get; set; }

    public virtual DbSet<WeatherCalendar> WeatherCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:PostgreSQL"]);
}
