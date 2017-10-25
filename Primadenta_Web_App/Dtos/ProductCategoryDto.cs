using System.ComponentModel.DataAnnotations;

namespace Primadenta_Web_App.Dtos
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}