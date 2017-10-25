using AutoMapper;
using Primadenta_Web_App.Dtos;
using Primadenta_Web_App.Models.BusinessData;

namespace Primadenta_Web_App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();

            Mapper.CreateMap<Company, CompanyDto>();
            Mapper.CreateMap<CompanyDto, Company>();

            Mapper.CreateMap<ProductCategory, ProductCategoryDto>();
            Mapper.CreateMap<ProductCategoryDto, ProductCategory>();
        }
    }
}