using AccuMicroService.Enitites;
using AccuMicroService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace AccuMicroService
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        private IConfiguration _configuration;
        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        //public virtual DbSet<RPrecipitation> RPrecipitations { get; set; }

        public virtual DbSet<RReestrObject> RReestrObjects { get; set; }

        public virtual DbSet<WeatherCalendar> WeatherCalendars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:PostgreSQL"]);
    }
}
