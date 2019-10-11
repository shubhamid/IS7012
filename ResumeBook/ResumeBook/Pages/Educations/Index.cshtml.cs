using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Pages.Educations
{
    public class IndexModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public IndexModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        public IList<Education> Education { get;set; }

        public async Task OnGetAsync()
        {
            Education = await _context.Education
                .Include(e => e.Candidate).ToListAsync();
        }
    }
}
