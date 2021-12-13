using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using MyFirstMVCApp.Data;
using System.Linq;

namespace MyFirstMVCApp.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new MyFirstMVCAppContext(serviceProvider.GetRequiredService<DbContextOptions<MyFirstMVCAppContext>>());
            if (context.Filmy.Any())
                return;

            context.Filmy.AddRange(
                new Filmy
                {
                    Name = "Pierwszy",
                    ReleaseDate = DateTime.Now,
                    Genre = "Gatunek1",
                    Price = 7.66M,
                    Rating = "A",
                },
                new Filmy
                {
                    Name = "Drugi",
                    ReleaseDate = DateTime.Now,
                    Genre = "Gatunek2",
                    Price = 6M,
                    Rating = "S",
                },
                new Filmy
                {
                    Name = "Trzeci",
                    ReleaseDate = DateTime.Now,
                    Genre = "Gatunek3",
                    Price = 4.3M,
                    Rating = "M",
                },
                new Filmy
                {
                    Name = "Czwarty",
                    ReleaseDate = DateTime.Now,
                    Genre = "Gatunek4",
                    Price = 2.332M,
                    Rating = "R",
                });
            context.SaveChanges();
        }
    }
}
