using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthDeptApp.Models;

namespace HealthDeptApp.Pages.EstablishmentCategories
{
    public class IndexModel : PageModel
    {
        private readonly HealthDeptApp.Models.AppDbContext _context;

        public IndexModel(HealthDeptApp.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<EstablishmentCategory> EstablishmentCategory { get;set; }

        public async Task OnGetAsync()
        {
            EstablishmentCategory = await _context.EstablishmentCategories.ToListAsync();
        }
    }
}
