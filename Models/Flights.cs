using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDSProject.Models
{
    public class Flights
    {
        public int Id { get; set; }

        [Required] public string Airline { get; set; }

        [Display(Name = "Departure Airport")]
        [Required] public string Departure_Airport { get; set; }

        [Display(Name = "Arrival Airport")]
        [Required] public string Arrival_Airport { get; set; }

        public string Flight_Time { get; set; }

        public decimal Price { get; set; }
    }
}
