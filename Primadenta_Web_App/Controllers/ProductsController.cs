using Primadenta_Web_App.Models.AppData;
using Primadenta_Web_App.Models.BusinessData;
using Primadenta_Web_App.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Primadenta_Web_App.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new NewProductViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                Companies = _context.Companies.ToList(),
                Product = new Product()
            };

            return View("Products", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel
                {
                    ProductCategories = _context.ProductCategories.ToList(),
                    Companies = _context.Companies.ToList(),
                    Product = product
                };

                return View("New", viewModel);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel
                {
                    ProductCategories = _context.ProductCategories.ToList(),
                    Companies = _context.Companies.ToList(),
                    Product = product
                };

                return View("New", viewModel);
            }
            var productFromDB = _context.Products.SingleOrDefault(p => p.Id == product.Id);

            if (productFromDB == null)
                return HttpNotFound();

            productFromDB.Name = product.Name;
            productFromDB.Packaging = product.Packaging;
            productFromDB.CompanyId = product.CompanyId;
            productFromDB.ProductCategoryId = product.ProductCategoryId;

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Edit(int id)
        {
            var productFromDB = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productFromDB == null)
                return HttpNotFound();

            var viewModel = new NewProductViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                Companies = _context.Companies.ToList(),
                Product = productFromDB
            };

            return PartialView("_Edit", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new NewProductViewModel
            {
                ProductCategories = _context.ProductCategories.ToList(),
                Companies = _context.Companies.ToList(),
                Product = new Product()
            };

            return View("New", viewModel);
        }
    }
}