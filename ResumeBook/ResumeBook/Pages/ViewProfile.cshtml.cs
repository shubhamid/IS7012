using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeBook.Pages
{
    public class ViewProfileModel : PageModel
    {
        private ResumeBookContext _context;

        public ViewProfileModel (ResumeBookContext context)
        {
            _context = context;
        }

        public Candidate Candidate { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Candidate = _context.Candidate
                    .Include(c => c.Educations)
                    .Include(c => c.Experiences)
                    .Include(c => c.Projects)
                    .FirstOrDefault(c => c.ID == id);
            if (Candidate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}