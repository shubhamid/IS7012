using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBook.Models
{
    public class UpdateProjectLanguage
    {
        public int ProjectId { get; set; }
        [Display(Name = "Project Language")]
        [Required(ErrorMessage = "Please provide a Project Language")]
        public string ProjectLanguage { get; set; }
    }
}
