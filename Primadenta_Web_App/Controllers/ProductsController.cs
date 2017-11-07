﻿using Primadenta_Web_App.Models.AppData;
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
            if (User.IsInRole("Admin"))
            {
                var viewModel = new NewProductViewModel
                {
                    ProductCategories = _context.ProductCategories.ToList(),
                    Companies = _context.Companies.ToList(),
                    Company = new Company(),
                    Product = new Product()
                };

                return View("Products_Admin", "_LayoutAdmin", viewModel);
            }

            return View("Products_NoRole");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel
                {
                    ProductCategories = _context.ProductCategories.ToList(),
                    Companies = _context.Companies.ToList(),
                    Product = product
                };

                return View("ModalShowProducts", viewModel);
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

                return View("ModalShowProducts", viewModel);
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

            return PartialView("ModalShowProducts", viewModel);
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SaveCompany(Company company)
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

            var companyFromDb = _context.Companies.SingleOrDefault(c => c.Name == company.Name);

            if (companyFromDb != null)
                return HttpNotFound("Tokia firma jau egzistuoja");

            _context.Companies.Add(company);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}