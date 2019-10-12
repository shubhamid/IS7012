using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeBook.Models;

namespace ResumeBook.Pages
{
    public class UpdateProjectLanguageFormModel : PageModel
    {
        private readonly ResumeBookContext _context;
        public UpdateProjectLanguageFormModel(ResumeBookContext context)
        {
            _context = context;
        }
        [BindProperty]
        public UpdateProjectLanguage UpdateProjectLanguage { get; set; }
        public Project Project { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project = _context.Project.Find(id);
            if (Project == null)
            {
                return NotFound();
            }
            UpdateProjectLanguage = new UpdateProjectLanguage();
            UpdateProjectLanguage.ProjectId = Project.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Project = _context.Project.Find(UpdateProjectLanguage.ProjectId);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Project.Language = UpdateProjectLanguage.ProjectLanguage;
            _context.SaveChanges();
            return RedirectToPage("/Projects/Details", new { id = Project.ID });
        }
    }
}