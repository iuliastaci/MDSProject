using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MDSProject.Data;
using System;
using System.Linq;


namespace MDSProject.Models
{
    public class SeedDataFlights
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MDSProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MDSProjectContext>>()))
            {
                if (! context.Flights.Any())
                {
                    context.Flights.AddRange(
                    new Flights
                    {
                        Airline = "Austrian Airlines",
                        Departure_Airport = "Bucharest",
                        Arrival_Airport = "Vienna",
                        Flight_Time = "1h30",
                        Price = 99
                    },
                    new Flights
                    {
                        Airline = "Air France",
                        Departure_Airport = "Paris",
                        Arrival_Airport = "Bucharest",
                        Flight_Time = "3h15",
                        Price = 175
                    },
                    new Flights
                    {
                        Airline = "British Airways",
                        Departure_Airport = "Bucharest",
                        Arrival_Airport = "London",
                        Flight_Time = "4h10",
                        Price = 241
                    },
                    new Flights
                    {
                        Airline = "Turkish Airlines",
                        Departure_Airport = "Istanbul",
                        Arrival_Airport = "Bucharest",
                        Flight_Time = "0h55",
                        Price = 105
                    },
                    new Flights
                    {
                        Airline = "TAROM",
                        Departure_Airport = "Bucharest",
                        Arrival_Airport = "Prague",
                        Flight_Time = "1h45",
                        Price = 283
                    }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}
