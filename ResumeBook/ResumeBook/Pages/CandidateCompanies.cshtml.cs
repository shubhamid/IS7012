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
    public class CandidateCompaniesModel : PageModel
    {
        private ResumeBookContext _context;

        public CandidateCompaniesModel(ResumeBookContext context)
        {
            _context = context;
        }
        public ICollection<Project> Projects { get; set; }
        public HashSet<int> SetOfCandidates = new HashSet<int>();
        public ICollection<Candidate> Candidates = new HashSet<Candidate>();
        public IActionResult OnGet(string language)
        {
            if(language == null)
            {
                return NotFound();
            }
            Projects = _context.Project
                .Where(p => p.Language == language)
                .ToList();
            if (Projects == null)
            {
                return NotFound();
            }
            foreach (Project p in Projects)
            {
                SetOfCandidates.Add(p.CandidateId);
            }
            foreach (int candidate in SetOfCandidates)
            {
                Candidates.Add(_context.Candidate.FirstOrDefault(f => f.ID == candidate));
            }
            return Page();
        }
    }
}