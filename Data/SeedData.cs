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
                // Check if there are any categories already in the database
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                // Add initial data for Categories
                var category1 = new Category
                {
                    Name = "Mammals"
                };

                var category2 = new Category
                {
                    Name = "Birds"
                };

                context.Categories.AddRange(category1, category2);
                context.SaveChanges(); // Save changes to get the Ids
                if (context.Animals.Any())
                {
                    return;   // DB has been seeded
                }

                // Add initial data for Enclosures
                var enclosure1 = new Enclosure
                {
                    Name = "Savannah Enclosure",
                    Description = "A large enclosure for savannah animals.",
                    Capacity = 10,
                    Climate = ClimateEnum.Temperate,
                    HabitatType = HabitatTypeEnum.Grassland,
                    SecurityLevel = SecurityLevelEnum.Medium,
                    Size = 500.0
                };

                var enclosure2 = new Enclosure
                {
                    Name = "Tropical Rainforest Enclosure",
                    Description = "A lush enclosure for tropical animals.",
                    Capacity = 15,
                    Climate = ClimateEnum.Tropical,
                    HabitatType = HabitatTypeEnum.Forest,
                    SecurityLevel = SecurityLevelEnum.High,
                    Size = 600.0
                };

                context.Enclosures.AddRange(enclosure1, enclosure2);
                context.SaveChanges(); // Save changes to get the Ids

                // Add initial data for Animals
                var animal1 = new Animal
                {
                    Name = "Lion",
                    Species = "Panthera leo",
                    Age = 5,
                    EnclosureId = enclosure1.Id,
                    Size = SizeEnum.Large,
                    DietaryClass = DietaryClassEnum.Carnivore,
                    ActivityPattern = ActivityPatternEnum.Diurnal,
                    Prey = "Zebras, Antelopes",
                    SpaceRequirement = 100.0,
                    SecurityRequirement = SecurityLevelEnum.High,
                    CategoryId = category1.Id 
                };

                var animal2 = new Animal
                {
                    Name = "Parrot",
                    Species = "Psittacidae",
                    Age = 2,
                    EnclosureId = enclosure2.Id, // Use the saved Id
                    Size = SizeEnum.Small,
                    DietaryClass = DietaryClassEnum.Herbivore,
                    ActivityPattern = ActivityPatternEnum.Diurnal,
                    Prey = "Seeds, Fruits",
                    SpaceRequirement = 5.0,
                    SecurityRequirement = SecurityLevelEnum.Low,
                    CategoryId = category2.Id // Assigning category
                };

                context.Animals.AddRange(animal1, animal2);
                context.SaveChanges();
            }
        }
    }
}
