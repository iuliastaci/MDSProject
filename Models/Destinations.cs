using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDSProject.Models
{
    public class Destinations
    {
        public int Id { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

        [Display (Name = "Best months to go")]
        public string Best_Months_to_go {get; set;}

        public string Expensiveness { get; set; }
    }
}
