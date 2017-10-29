using AutoMapper;
using Primadenta_Web_App.Dtos;
using Primadenta_Web_App.Models.AppData;
using Primadenta_Web_App.Models.BusinessData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Primadenta_Web_App.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetProducts(string query = null)
        {
            IEnumerable<ProductDto> productDto;

            if (!String.IsNullOrWhiteSpace(query))
                productDto = _context.Products
                    .Include(c => c.Company)
                    .Include(p => p.ProductCategory)
                    .ToList()
                    .Select(Mapper.Map<Product, ProductDto>);
            else
                productDto = _context.Products
                    .Include(c => c.Company)
                    .Include(p => p.ProductCategory)
                    .ToList()
                    .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDto);
        }

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            List<Product> productDto = new List<Product>();

            var productFromDb = _context.Products
                .Include(c => c.Company)
                .Include(p => p.ProductCategory)
                .SingleOrDefault(p => p.Id == id);

            productDto.Add(productFromDb);

            if (productFromDb == null)
                return NotFound();



            //return Ok(Mapper.Map<Product, ProductDto>(productFromDb));
            return Ok(productDto);
        }

        [HttpGet]
        public IHttpActionResult GetProductByCategory(int categoryId)
        {
            List<Product> productDto = new List<Product>();

            var productFromDb = _context.Products
                .Include(c => c.Company)
                .Include(p => p.ProductCategory)
                .Where(p => p.ProductCategoryId == categoryId)
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);

            //productDto.Add(productFromDb);

            if (productFromDb == null)
                return NotFound();



            //return Ok(Mapper.Map<Product, ProductDto>(productFromDb));
            return Ok(productFromDb);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productFromDb = _context.Products
                .SingleOrDefault(p => p.Id == id);

            if (productFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(productDto, productFromDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productFromDb = _context.Products
                .SingleOrDefault(p => p.Id == id);

            if (productFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Products.Remove(productFromDb);
            _context.SaveChanges();
        }
    }
}
