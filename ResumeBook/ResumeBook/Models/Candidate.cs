using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Headline { get; set; }
        public string CurrentEducation { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Region { get; set; }
        public string Industry { get; set; }
        public string Email { get; set; }
        public decimal TotalYearsOfExperience { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Education> Educations { get; set; }

    }
}
