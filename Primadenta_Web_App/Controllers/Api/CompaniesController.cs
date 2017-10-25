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
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetCompanies(string query = null)
        {
            IEnumerable<CompanyDto> companyDto;

            if (!String.IsNullOrWhiteSpace(query))
                companyDto = _context.Companies
                    .Where(c => c.Name.Contains(query))
                    .ToList()
                    .Select(Mapper.Map<Company, CompanyDto>);
            else
                companyDto = _context.Companies
                    .ToList()
                    .Select(Mapper.Map<Company, CompanyDto>);

            return Ok(companyDto);
        }

        [HttpGet]
        public IHttpActionResult GetCompany(int id)
        {
            var companyFromDb = _context.Companies
                .SingleOrDefault(c => c.Id == id);

            if (companyFromDb == null)
                return NotFound();

            return Ok(Mapper.Map<Company, CompanyDto>(companyFromDb));
        }

        [HttpPost]
        public IHttpActionResult CreateCompany(CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = Mapper.Map<CompanyDto, Company>(companyDto);

            _context.Companies.Add(company);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + company.Id), companyDto);
        }

        [HttpPut]
        public void UpdateCompany(int id, CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var companyFromDb = _context.Companies
                .SingleOrDefault(c => c.Id == id);

            if (companyFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(companyDto, companyFromDb);

            _context.SaveChanges();
        }

        //[HttpDelete]
        //public void DeleteCompany(int id)
        //{
        //    var companyFromDb = _context.Companies
        //        .SingleOrDefault(c => c.Id == id);

        //    if (companyFromDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _context.Companies.Remove(companyFromDb);
        //    _context.SaveChanges();
        //}
    }
}
