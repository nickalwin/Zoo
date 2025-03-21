using System;
using Microsoft.Extensions.DependencyInjection; 
using ZooNick.Data; 
using ZooNick.Models; 
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ZooNick.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ZooContext(
                serviceProvider.GetRequiredService<DbContextOptions<ZooContext>>()))
            {
                // Check if the database has been created
                context.Database.EnsureCreated();

                // Check if there are any animals already in the database
                if (context.Animals.Any())
                {
                    return; // DB has been seeded
                }

                // Seed data
                context.Animals.AddRange(
                    new Animal { Name = "Lion", Species = "Panthera leo", Age = 5, EnclosureId = 1, CategoryId = 1 },
                    new Animal { Name = "Elephant", Species = "Loxodonta", Age = 10, EnclosureId = 2, CategoryId = 2 }
                );

                context.Enclosures.AddRange(
                    new Enclosure { Name = "Savannah", Description = "Open area", Capacity = 10 },
                    new Enclosure { Name = "Forest", Description = "Closed area", Capacity = 5 }
                );

                context.Categories.AddRange(
                    new Category { Name = "Mammals" },
                    new Category { Name = "Birds" }
                );

                context.SaveChanges();
            }
        }
    }
}
