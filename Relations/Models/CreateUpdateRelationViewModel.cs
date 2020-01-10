using System;
using System.ComponentModel.DataAnnotations;

namespace RelationApp.Models
{
    public class CreateUpdateRelationViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Telephone number")]
        public string TelephoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string DefaultCountry { get; set; }

        [Required]
        [Display(Name = "City")]
        public string DefaultCity { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string DefaultStreet { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string DefaultPostalCode { get; set; }
    }
}
