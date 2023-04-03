using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MDSProject.Models
{
    public class ClientCountryViewModel
    {
        public List<Clients>? Clients { get; set; }
        public SelectList? Country { get; set; }

        public string? ClientCountry { get; set; }

        public string? SearchString { get; set; }
    }
}
