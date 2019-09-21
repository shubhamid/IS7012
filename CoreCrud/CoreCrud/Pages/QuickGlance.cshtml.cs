using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class QuickGlanceModel : PageModel
    {
        private CoreCrud09212019Context _context;
        public QuickGlanceModel(CoreCrud09212019Context context)
        {
            _context = context;
        }
        public ICollection<Destination> Destinations { get; set; }
        public void OnGet()
        {
            Destinations = _context.Destination
                            .OrderBy(x => x.DestinationName)
                            .ToList();
        }
    }
}