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
        public string Packaging { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}