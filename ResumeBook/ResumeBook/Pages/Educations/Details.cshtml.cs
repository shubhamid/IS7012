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
    public class DetailsModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public DetailsModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        public Education Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Education = await _context.Education
                .Include(e => e.Candidate).FirstOrDefaultAsync(m => m.ID == id);

            if (Education == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
