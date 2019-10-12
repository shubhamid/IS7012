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
        [Required(ErrorMessage = "Please provide a School")]
        public string School { get; set; }
        [Required(ErrorMessage = "Please provide a Degree")]
        public string Degree { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Start Date")]
        [CustomValidation(typeof(Education), "StartDateValidation")]
        [CustomValidation(typeof(Education), "StartDateBeforeEndDateValidation")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please provide a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please provide a Country")]
        public string Country { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        // read-only property - 3
        public bool hasGraduated
        {
            get
            {
                return EndDate < DateTime.Today;
            }
        }

        // custom validations - 2
        public static ValidationResult StartDateValidation(DateTime? StartDate, ValidationContext context)
        {
            if (StartDate == null)
            {
                return ValidationResult.Success;
            }
            string errorMessage = "Start date must be a date on or before today.";
            if (StartDate.Value.Date > DateTime.Today)
            {
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }

        // custom validations - 3
        public static ValidationResult StartDateBeforeEndDateValidation(DateTime? StartDate, ValidationContext context)
        {
            if (StartDate == null)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Education;
            string errorMessage = "Start date must be before End date.";
            if (StartDate.Value.Date > instance.EndDate)
            {
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
