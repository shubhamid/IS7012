using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeBook.Models;

namespace ResumeBook.Pages
{
    public class UpdateCurrentEducationFormModel : PageModel
    {
        private readonly ResumeBookContext _context;
        public UpdateCurrentEducationFormModel(ResumeBookContext context)
        {
            _context = context;
        }
        [BindProperty]
        public UpdateCurrentEducation UpdateCurrentEducation { get; set; }
        public Candidate Candidate { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Candidate = _context.Candidate.Find(id);
            if (Candidate == null)
            {
                return NotFound();
            }
            UpdateCurrentEducation = new UpdateCurrentEducation();
            UpdateCurrentEducation.CandidateId = Candidate.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Candidate = _context.Candidate.Find(UpdateCurrentEducation.CandidateId);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Candidate.CurrentEducation = UpdateCurrentEducation.CurrentEducation;
            _context.SaveChanges();
            return RedirectToPage("/Candidates/Details", new { id = Candidate.ID });
        }
    }
}