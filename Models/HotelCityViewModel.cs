using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MDSProject.Models
{
    public class HotelCityViewModel
    {
        public List<Hotels>? Hotels { get; set; }

        public SelectList? City { get; set; }

        public string? HotelCity { get; set; }

        public string? SearchString { get; set; }
    }
}
