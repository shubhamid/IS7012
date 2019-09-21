using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrud09212019Context _context;

        public IndexModel(CoreCrud09212019Context context)
        {
            _context = context;
        }
        public ICollection<Destination> Destinations { get; set; }
        public void OnGet()
        {
            CountOfDestinations = _context.Destination
                            .Count();
            CountOfOvernightStays = _context.Destination
                            .Where(x => x.OvernightStay == true)
                            .Count();
        }
        public int CountOfDestinations { get; set; }
        public int CountOfOvernightStays { get; set; }
    }
}
