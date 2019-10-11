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
    public class DeleteModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public DeleteModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Education = await _context.Education.FindAsync(id);

            if (Education != null)
            {
                _context.Education.Remove(Education);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
