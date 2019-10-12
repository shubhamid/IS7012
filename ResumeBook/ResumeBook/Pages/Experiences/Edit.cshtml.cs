using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Pages.Experiences
{
    public class EditModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public EditModel(ResumeBook.Models.ResumeBookContext context)
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
           ViewData["CandidateId"] = new SelectList(_context.Candidate, "ID", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(Experience.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.ID == id);
        }
    }
}
