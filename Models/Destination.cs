using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Destination
    {
        public int ID { get; set;}
        public string DestinationName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool OvernightStay { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AverageTemp { get; set; }

        // relationship
        public int LocationId { get; set; }
        public Country Location { get; set; }

    }
}
