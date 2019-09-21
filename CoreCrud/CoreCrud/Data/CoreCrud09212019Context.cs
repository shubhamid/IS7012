using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Models
{
    public class CoreCrud09212019Context : DbContext
    {
        public CoreCrud09212019Context (DbContextOptions<CoreCrud09212019Context> options)
            : base(options)
        {
        }

        public DbSet<CoreCrud.Models.Country> Country { get; set; }

        public DbSet<CoreCrud.Models.Destination> Destination { get; set; }
    }
}
