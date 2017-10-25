using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primadenta_Web_App.Models.BusinessData
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Įveskite kategoriją")]
        [MaxLength(150)]
        [Index("IX_CategoryName", 1, IsUnique = true)]
        [Display(Name = "Kategorija")]
        public string Name { get; set; }
    }
}