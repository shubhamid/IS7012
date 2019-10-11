using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResumeBook.Models;

namespace ResumeBook.Pages.Experiences
{
    public class CreateModel : PageModel
    {
        private readonly ResumeBook.Models.ResumeBookContext _context;

        public CreateModel(ResumeBook.Models.ResumeBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CandidateId"] = new SelectList(_context.Candidate, "ID", "Country");
            return Page();
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Experience.Add(Experience);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}