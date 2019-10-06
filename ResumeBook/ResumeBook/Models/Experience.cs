using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool CurrentlyWorkingHere { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
