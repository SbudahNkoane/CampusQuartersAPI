using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Data
{
    public class CampusQuartersDataContext:DbContext
    {
        public CampusQuartersDataContext(DbContextOptions<CampusQuartersDataContext> options):base(options) 
        {
            
        }
    }
}
