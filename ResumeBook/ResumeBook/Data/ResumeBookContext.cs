using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Models
{
    public class ResumeBookContext : DbContext
    {
        public ResumeBookContext (DbContextOptions<ResumeBookContext> options)
            : base(options)
        {
        }

        public DbSet<ResumeBook.Models.Candidate> Candidate { get; set; }

        public DbSet<ResumeBook.Models.Education> Education { get; set; }

        public DbSet<ResumeBook.Models.Experience> Experience { get; set; }

        public DbSet<ResumeBook.Models.Project> Project { get; set; }
    }
}
