using AutoMapper;
using Primadenta_Web_App.Dtos;
using Primadenta_Web_App.Models.AppData;
using Primadenta_Web_App.Models.BusinessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Primadenta_Web_App.Controllers.Api
{
    public class ProductCategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductCategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetProductCategories(string query = null)
        {
            IEnumerable<ProductCategoryDto> productCategoryDto;

            if (!String.IsNullOrWhiteSpace(query))
                productCategoryDto = _context.ProductCategories
                    .Where(c => c.Name.Contains(query))
                    .ToList()
                    .Select(Mapper.Map<ProductCategory, ProductCategoryDto>);
            else
                productCategoryDto = _context.ProductCategories
                    .ToList()
                    .Select(Mapper.Map<ProductCategory, ProductCategoryDto>);

            return Ok(productCategoryDto);
        }

        [HttpGet]
        public IHttpActionResult GetProductCategory(int id)
        {
            var productCategoryFromDb = _context.ProductCategories
                .SingleOrDefault(c => c.Id == id);

            if (productCategoryFromDb == null)
                return NotFound();

            return Ok(Mapper.Map<ProductCategory, ProductCategoryDto>(productCategoryFromDb));
        }

        [HttpPost]
        public IHttpActionResult CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productCategory = Mapper.Map<ProductCategoryDto, ProductCategory>(productCategoryDto);

            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + productCategory.Id), productCategoryDto);
        }

        [HttpPut]
        public void UpdateProductCategory(int id, ProductCategoryDto productCategoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productCategoryFromDb = _context.ProductCategories
                .SingleOrDefault(c => c.Id == id);

            if (productCategoryFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(productCategoryDto, productCategoryFromDb);

            _context.SaveChanges();
        }

        //[HttpDelete]
        //public void DeleteProductCategory(int id)
        //{
        //    var productCategoryFromDb = _context.ProductCategories
        //        .SingleOrDefault(c => c.Id == id);

        //    if (productCategoryFromDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _context.ProductCategories.Remove(productCategoryFromDb);
        //    _context.SaveChanges();
        //}
    }
}
