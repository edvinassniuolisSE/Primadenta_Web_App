using Primadenta_Web_App.Models.AppData;
using Primadenta_Web_App.Models.BusinessData;
using Primadenta_Web_App.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Primadenta_Web_App.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Company company)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel
                {
                    ProductCategories = _context.ProductCategories.ToList(),
                    Companies = _context.Companies.ToList(),
                    Company = company
                };

                return RedirectToAction("Index", "Products", viewModel);
            }

            _context.Companies.Add(company);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}