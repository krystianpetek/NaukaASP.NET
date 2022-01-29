using Microsoft.EntityFrameworkCore;
using Lab5Buzowicz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lab5Buzowicz
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductEntity> uzytkownicy { get; set; }
    }
}