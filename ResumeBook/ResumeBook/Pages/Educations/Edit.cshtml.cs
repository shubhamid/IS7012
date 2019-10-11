using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeBook.Models;

namespace ResumeBook.Pages.Educations
{
    public class EditModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public EditModel(ResumeBook.Models.ResumeBookContext context)
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
           ViewData["CandidateId"] = new SelectList(_context.Candidate, "ID", "Country");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(Education.ID))
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

        private bool EducationExists(int id)
        {
            return _context.Education.Any(e => e.ID == id);
        }
    }
}
