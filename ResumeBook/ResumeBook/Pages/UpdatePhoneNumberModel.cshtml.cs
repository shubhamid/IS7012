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
    public class UpdatePhoneNumberModelModel : PageModel
    {
        private readonly ResumeBookContext _context;
        public UpdatePhoneNumberModelModel(ResumeBookContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ChangePhoneNumber ChangePhoneNumber { get; set; }
        public Candidate Candidate { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Candidate = _context.Candidate.Find(id);
            if(Candidate == null)
            {
                return NotFound();
            }
            ChangePhoneNumber = new ChangePhoneNumber();
            ChangePhoneNumber.CandidateId = Candidate.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Candidate = _context.Candidate.Find(ChangePhoneNumber.CandidateId);

            if(!ModelState.IsValid)
            {
                return Page();
            }
            Candidate.PhoneNumber = ChangePhoneNumber.PhoneNumber;
            _context.SaveChanges();
            return RedirectToPage("/Candidates/Details", new { id = Candidate.ID });
        }
    }
}