using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a Name")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Destination> Destinations { get; set; }
    }
}
