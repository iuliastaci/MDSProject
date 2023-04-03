using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MDSProject.Data;
using System;
using System.Linq;

namespace MDSProject.Models
{
    public class SeedDataDestinations
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MDSProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MDSProjectContext>>()))
            {
                // Look for any movies.
                if (!context.Destinations.Any())
                {
                    context.Destinations.AddRange(
                    new Destinations
                    {
                        City = "Bucharest",
                        Country = "Romania",
                        Best_Months_to_go = "April-June & September-October",
                        Expensiveness = "$$"
                    },
                    new Destinations
                    {
                        City = "Prague",
                        Country = "Czech Republic",
                        Best_Months_to_go = "May & September",
                        Expensiveness = "$$"
                    },
                    new Destinations
                    {
                        City = "Vienna",
                        Country = "Austria",
                        Best_Months_to_go = "April-May & September-October",
                        Expensiveness = "$$$"
                    },
                    new Destinations
                    {
                        City = "Budapest",
                        Country = "Hungary",
                        Best_Months_to_go = "May-June & September-early October",
                        Expensiveness = "$$"
                    },
                    new Destinations
                    {
                        City = "Paris",
                        Country = "France",
                        Best_Months_to_go = "June-October",
                        Expensiveness = "$$$$"
                    },
                    new Destinations
                    {
                        City = "London",
                        Country = "United Kingdom",
                        Best_Months_to_go = "May-June & Sepetember-October",
                        Expensiveness = "$$$$"
                    },
                    new Destinations 
                    { 
                        City = "Istanbul",
                        Country = "Turkey",
                        Best_Months_to_go = "March-May & september-November",
                        Expensiveness = "$"
                    }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}
