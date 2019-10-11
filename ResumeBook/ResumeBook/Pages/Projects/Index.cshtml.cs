using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public IndexModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Project
                .Include(p => p.Candidate).ToListAsync();
        }
    }
}
