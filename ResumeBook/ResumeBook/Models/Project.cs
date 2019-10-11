using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please provide a Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide the Language used in this project")]
        public string Language { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
