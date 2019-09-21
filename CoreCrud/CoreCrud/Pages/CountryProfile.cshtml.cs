using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class CountryProfileModel : PageModel
    {
        private CoreCrud09212019Context _context;

        public CountryProfileModel(CoreCrud09212019Context context)
        {
            _context = context;
        }

        public Country Country { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Country = _context.Country
                        .Include(c => c.Destinations)
                        .FirstOrDefault(c => c.ID == id);
            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}