using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDSProject.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)] 
        public DateTime Birthday { get; set; }
    }
}
