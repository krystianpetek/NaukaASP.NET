using Lab4Buzowicz.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4Buzowicz.Database
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> studenci { get; set; }
    }
}
