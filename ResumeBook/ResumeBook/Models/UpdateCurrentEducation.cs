using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class UpdateCurrentEducation
    {
        public int CandidateId { get; set; }
        [Display(Name = "Current Education")]
        [Required(ErrorMessage = "Please provide a Current Education")]
        public string CurrentEducation { get; set; }
    }
}
