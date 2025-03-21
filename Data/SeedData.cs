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
                var mammalsCategory = new Category { Name = "Mammals", Description = "Warm-blooded animals with hair or fur." };
                var birdsCategory = new Category { Name = "Birds", Description = "Feathered animals that lay eggs." };
                context.Categories.AddRange(mammalsCategory, birdsCategory);
                context.SaveChanges(); // Save categories first

                var savannahEnclosure = new Enclosure { Name = "Savannah", Description = "Open area", Capacity = 10 };
                var forestEnclosure = new Enclosure { Name = "Forest", Description = "Closed area", Capacity = 5 };
                context.Enclosures.AddRange(savannahEnclosure, forestEnclosure);
                context.SaveChanges(); // Save enclosures first

                context.Animals.AddRange(
                    new Animal { Name = "Lion", Species = "Panthera leo", Age = 5, EnclosureId = savannahEnclosure.Id, CategoryId = mammalsCategory.Id },
                    new Animal { Name = "Elephant", Species = "Loxodonta", Age = 10, EnclosureId = forestEnclosure.Id, CategoryId = mammalsCategory.Id }
                );

                context.SaveChanges();
            }
        }
    }
}
