﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Countries
{
    public class DetailsModel : PageModel
    {
        private readonly CoreCrud.Models.CoreCrud09212019Context _context;

        public DetailsModel(CoreCrud.Models.CoreCrud09212019Context context)
        {
            _context = context;
        }

        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await _context.Country.FirstOrDefaultAsync(m => m.ID == id);

            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
