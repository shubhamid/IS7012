using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class ChangePhoneNumber
    {
        public int CandidateId { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please provide a Phone Number")]
        [RegularExpression(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }
    }
}