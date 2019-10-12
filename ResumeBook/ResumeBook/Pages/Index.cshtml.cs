using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeBook.Models;

namespace ResumeBook.Pages
{
    public class IndexModel : PageModel
    {
        private ResumeBookContext _context;
        public IndexModel(ResumeBookContext context)
        {
            _context = context;
        }
        public int CountOfStudents { get; set; }
        public int CountOfProjects{ get; set; }
        public void OnGet()
        {
            CountOfStudents = _context.Candidate
                            .Count();
            CountOfProjects = _context.Project
                            .Where(x => x.Language == "Java")
                            .Count();
        }
    }
}
