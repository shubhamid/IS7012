using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide a First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide a Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Headline")]
        public string Headline { get; set; }
        [Display(Name = "Current Education")]
        public string CurrentEducation { get; set; }
        [Required(ErrorMessage = "Please provide a Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please provide a Zipcode")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please provide a Region")]
        public string Region { get; set; }
        public string Industry { get; set; }
        [Required(ErrorMessage = "Please provide an Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }
        [Display(Name = "Total Years Of Experience")]
        public decimal TotalYearsOfExperience { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please provide a Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "About")]
        public string About { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Education> Educations { get; set; }

        // read-only property - 1
        public bool IsAStudent
        {
            get
            {
                return CurrentEducation.Length != 0;
            }
        }

        // read-only property - 2
        public bool IsInUSA
        {
            get
            {
                return Country.Equals("USA");
            }
        }

        // custom validation - 1
        public static ValidationResult EmailEduValidation(string Email, ValidationContext context)
        {
            if (Email == null)
            {
                return ValidationResult.Success;
            }
            if (!Email.EndsWith(".edu"))
            {
                return new ValidationResult("Enter your .edu email address");
            }
            return ValidationResult.Success;
        }
    }

}
