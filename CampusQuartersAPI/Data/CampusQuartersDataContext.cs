using CampusQuartersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Data
{
    public class CampusQuartersDataContext:DbContext
    {
        public CampusQuartersDataContext(DbContextOptions<CampusQuartersDataContext> options):base(options) 
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<AccommodationImage> AccommodationImages { get; set; }
        public DbSet<AccommodationVideo> AccommodationVideos { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; } 

    }
}
