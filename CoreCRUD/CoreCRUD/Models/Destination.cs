using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Destination
    {
        public int ID { get; set;}

        [Required(ErrorMessage = "Please provide a Destination Name")]
        [StringLength(100, MinimumLength = 2)]
        [CustomValidation(typeof(Destination), "DestinationNameValidation")]
        [Display(Name = "Destination Name")]
        public string DestinationName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Destination), "ArrivalTimeValidation")]
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Overnight Stay")]
        public bool OvernightStay { get; set; }

        [Display(Name = "Average Temperature")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AverageTemp { get; set; }

        [Display(Name = "Agent Email")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string CityAgentEmailAddress { get; set; }

        [Display(Name = "Agent Phone")]
        [Phone(ErrorMessage = "Please provide a valid US phone number")]
        [StringLength(11, MinimumLength = 7)]
        public string CityAgentCellPhone { get; set; }

        [Display(Name = "Instagram Profile")]
        [Url(ErrorMessage = "Please provide a valid Instagram url")]
        [StringLength(500)]
        public string CityInstagramProfile { get; set; }

        // relationship
        public int LocationId { get; set; }
        public Country Location { get; set; }

        [NotMapped]
        public int IsAccomodationRequired
        {
            get
            {
                return DateTime.Compare(DateTime.Now, ArrivalTime);
            }
        }

        public static ValidationResult ArrivalTimeValidation(DateTime? arrivalDate, ValidationContext context)
        {
            if (arrivalDate == null)
            {
                return ValidationResult.Success;
            }
            if (arrivalDate.Value.Date > DateTime.Today)
            {
                return ValidationResult.Success;
            }
            string errorMessage = $"Arrival date must be a date on or after today.";
            return new ValidationResult(errorMessage);
        }

        public static ValidationResult DestinationNameValidation(string destinationName, ValidationContext context)
        {
            if(destinationName == null)
            {
                return ValidationResult.Success;
            }
            if (destinationName.Any(char.IsLetter))
            {
                return ValidationResult.Success;
            }
            string errorMessage = "Destination Name shouldn't contain numbers";
            return new ValidationResult(errorMessage);
        }
    }

}
