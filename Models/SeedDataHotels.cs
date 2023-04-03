using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MDSProject.Data;
using System;
using System.Linq;


namespace MDSProject.Models
{
    public class SeedDataHotels
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MDSProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MDSProjectContext>>()))
            {
                if (! context.Hotels.Any())
                {
                    context.Hotels.AddRange(
                    new Hotels
                    {
                        Name = "Novotel",
                        City = "Bucharest",
                        Price = 165,
                        Stars = 4
                    },
                    new Hotels
                    {
                        Name = "Hotel Sacher",
                        City = "Vienna",
                        Price = 576,
                        Stars = 5
                    },
                    new Hotels
                    {
                        Name = "Bram",
                        City = "Istanbul",
                        Price = 106,
                        Stars = 3
                    },
                    new Hotels
                    {
                        Name = "Alta Moda Fashion Hotel",
                        City = "Budapest",
                        Price = 114,
                        Stars = 4
                    },
                    new Hotels
                    {
                        Name = "Green Garden",
                        City = "Prague",
                        Price = 77,
                        Stars = 3
                    },
                    new Hotels
                    {
                        Name = "Ritz",
                        City = "Paris",
                        Price = 2074,
                        Stars = 5
                    },
                    new Hotels
                    {
                        Name = "The Savoy",
                        City = "London",
                        Price = 910,
                        Stars = 5
                    }

                );
                    context.SaveChanges();
                }
            }
        }
    }
}
