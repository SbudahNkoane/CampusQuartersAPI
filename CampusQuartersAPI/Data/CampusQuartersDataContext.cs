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
    }
}
