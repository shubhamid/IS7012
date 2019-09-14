using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCRUD.Models;
using CoreCrud.Models;

namespace CoreCRUD.Pages.Destinations
{
    public class DetailsModel : PageModel
    {
        private readonly CoreCRUD.Models.CoreCRUDContext _context;

        public DetailsModel(CoreCRUD.Models.CoreCRUDContext context)
        {
            _context = context;
        }

        public Destination Destination { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Destination = await _context.Destination
                .Include(d => d.Location).FirstOrDefaultAsync(m => m.ID == id);

            if (Destination == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
