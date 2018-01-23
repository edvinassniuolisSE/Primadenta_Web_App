using System.ComponentModel.DataAnnotations;

namespace Primadenta_Web_App.Models.BusinessData
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Įveskite produkto pavadinimą")]
        [Display(Name = "Produktas")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Įveskite įpakavimą")]
        [Display(Name = "Pakuotė")]
        public string Packaging { get; set; }

        [Required]
        [Display(Name = "Firma")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [Display(Name = "Kategorija")]
        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}