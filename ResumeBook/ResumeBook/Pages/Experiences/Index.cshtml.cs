using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Pages.Experiences
{
    public class IndexModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public IndexModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        public IList<Experience> Experience { get;set; }

        public async Task OnGetAsync()
        {
            Experience = await _context.Experience
                .Include(e => e.Candidate).ToListAsync();
        }
    }
}
