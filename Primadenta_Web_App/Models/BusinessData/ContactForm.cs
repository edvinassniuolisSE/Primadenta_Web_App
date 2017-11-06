using System.ComponentModel.DataAnnotations;

namespace Primadenta_Web_App.Models.BusinessData
{
    public class ContactForm
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Vardas")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Pavardė")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Elektroninio pašto adresas")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tema")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Žinutė")]
        public string Message { get; set; }
    }
}