using Primadenta_Web_App.Models.BusinessData;
using System.Collections.Generic;

namespace Primadenta_Web_App.ViewModels
{
    public class NewProductViewModel
    {
        public Product Product { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}