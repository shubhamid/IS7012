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
    public class IndexModel : PageModel
    {
        private readonly CoreCRUD.Models.CoreCRUDContext _context;

        public IndexModel(CoreCRUD.Models.CoreCRUDContext context)
        {
            _context = context;
        }

        public IList<Destination> Destination { get;set; }

        public async Task OnGetAsync()
        {
            Destination = await _context.Destination
                .Include(d => d.Location).ToListAsync();
        }
    }
}
