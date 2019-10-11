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
    public class DeleteModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public DeleteModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Experience = await _context.Experience
                .Include(e => e.Candidate).FirstOrDefaultAsync(m => m.ID == id);

            if (Experience == null)
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

            Experience = await _context.Experience.FindAsync(id);

            if (Experience != null)
            {
                _context.Experience.Remove(Experience);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
