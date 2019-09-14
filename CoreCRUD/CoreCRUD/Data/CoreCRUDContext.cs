using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCRUD.Models
{
    public class CoreCRUDContext : DbContext
    {
        public CoreCRUDContext (DbContextOptions<CoreCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<CoreCrud.Models.Destination> Destination { get; set; }
    }
}
