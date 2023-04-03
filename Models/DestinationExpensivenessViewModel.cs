using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MDSProject.Models
{
    public class DestinationExpensivenessViewModel
    {
        public List<Destinations>? Destinations { get; set; }

        public SelectList? Expensiveness { get; set; }

        public string? DestinationExpensiveness { get; set; }

        public string? SearchString { get; set; }
    }
}
