using System.ComponentModel.DataAnnotations;

namespace Primadenta_Web_App.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}