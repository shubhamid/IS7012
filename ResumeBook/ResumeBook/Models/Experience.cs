using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Experience
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please provide a Company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Please provide a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please provide a Country")]
        public string Country { get; set; }
        [Display(Name = "Are you currently working here?")]
        public bool CurrentlyWorkingHere { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
