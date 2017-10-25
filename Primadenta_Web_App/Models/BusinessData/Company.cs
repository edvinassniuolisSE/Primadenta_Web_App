using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primadenta_Web_App.Models.BusinessData
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Įveskite firmos pavadinimą")]
        [MaxLength(40)]
        [Index("IX_CompanyName", 1, IsUnique = true)]
        [Display(Name = "Firma")]
        public string Name { get; set; }
    }
}