using CityManager.WebAPI.models;
using Microsoft.EntityFrameworkCore;

namespace CityManager.WebAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public ApplicationDbContext()
        {
                
        }
        public virtual DbSet<City> Cities { get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City { cityId= Guid.Parse ("{4095E157-F73E-4227-A846-C93036AABC94}"), cityName="Finlande" });
            modelBuilder.Entity<City>().HasData(new City { cityId= Guid.Parse("{A0E25CE7-3F87-46C0-9962-B0E4D1DB2D22}"), cityName="Toulouse" });
        }
    }
}
