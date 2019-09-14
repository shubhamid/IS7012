using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCRUD.Models;
using CoreCrud.Models;

namespace CoreCRUD.Pages.Destinations
{
    public class CreateModel : PageModel
    {
        private readonly CoreCRUD.Models.CoreCRUDContext _context;

        public CreateModel(CoreCRUD.Models.CoreCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Destination Destination { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Destination.Add(Destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}