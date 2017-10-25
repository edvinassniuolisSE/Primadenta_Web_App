using System.ComponentModel.DataAnnotations;

namespace Primadenta_Web_App.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Packaging { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public CompanyDto Company { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }
    }
}