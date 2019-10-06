using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Education
    {
        public int ID { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartYear { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndYear { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
