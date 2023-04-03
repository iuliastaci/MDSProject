using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MDSProject.Data;
using System;
using System.Linq;

namespace MDSProject.Models
{
    public class SeedDataClients
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MDSProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MDSProjectContext>>()))
            {
                // Look for any movies.
                if (! context.Clients.Any())
                {
                    context.Clients.AddRange(
                    new Clients
                    {
                        Name = "Maria Ion",
                        Birthday = DateTime.Parse("1989-2-12"),
                        Phone = "+40734256734",
                        Email = "maria.ion@yahoo.com",
                        Country = "Romania"
                    },
                    new Clients
                    {
                        Name = "Andrei Marin",
                        Birthday = DateTime.Parse("2000-4-18"),
                        Phone = "+40728364716",
                        Email = "amarin@yahoo.com",
                        Country = "Romania"
                    },
                    new Clients
                    {
                        Name = "Bill Andrew",
                        Birthday = DateTime.Parse("1993-12-12"),
                        Phone = "+40734256734",
                        Email = "bill_andrew@gmail.com",
                        Country = "Great Britain "
                    },
                    new Clients
                    {
                        Name = "Dan Alexandru",
                        Birthday = DateTime.Parse("1987-3-29"),
                        Phone = "+40721673982",
                        Email = "danalex@gmail.com",
                        Country = "Romania"
                    }
                );
                    context.SaveChanges();
                }
                
            }
        }
    }
}
