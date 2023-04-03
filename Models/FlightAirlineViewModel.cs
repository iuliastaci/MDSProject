using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MDSProject.Models
{
    public class FlightAirlineViewModel
    {
        public List<Flights>? Flights { get; set; }

        public SelectList? Airline { get; set; }

        public string? FlightAirline { get; set; }

        public string? SearchString { get; set; }
    }
}
