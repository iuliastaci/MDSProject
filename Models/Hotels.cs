using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDSProject.Models
{
    public class Hotels
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string City { get; set; }

        public decimal Price { get; set; }

        public decimal Stars { get; set; }
    }
}
