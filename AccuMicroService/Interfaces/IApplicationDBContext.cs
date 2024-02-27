using AccuMicroService.Enitites;
using Microsoft.EntityFrameworkCore;

namespace AccuMicroService.Interfaces
{
    public interface IApplicationDBContext
    {

        public DbSet<RReestrObject> RReestrObjects { get; set; }

        public DbSet<WeatherCalendar> WeatherCalendars { get; set; }

        public int SaveChanges();
    }
}
