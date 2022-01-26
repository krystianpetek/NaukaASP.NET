using Microsoft.EntityFrameworkCore;
using Lab3Buzowicz.Entities;
namespace Lab3Buzowicz.Database
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProduktEntity> Products { get; set; }
    }
}
