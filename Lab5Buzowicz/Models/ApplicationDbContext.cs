using Microsoft.EntityFrameworkCore;
using Lab5Buzowicz.Models;
namespace Lab5Buzowicz
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductEntity> products { get; set; }
    }
}