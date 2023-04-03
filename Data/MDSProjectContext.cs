using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MDSProject.Models;

namespace MDSProject.Data
{
    public class MDSProjectContext : DbContext
    {
        public MDSProjectContext (DbContextOptions<MDSProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MDSProject.Models.Clients> Clients { get; set; } = default!;

        public DbSet<MDSProject.Models.Destinations> Destinations { get; set; } = default!;

        public DbSet<MDSProject.Models.Hotels> Hotels { get; set; } = default!;

        public DbSet<MDSProject.Models.Flights> Flights { get; set; } = default!;
    }
}
