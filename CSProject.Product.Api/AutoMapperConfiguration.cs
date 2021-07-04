using AutoMapper;
using CSProject.Dto.DataDto;
using CSProject.Product.Data.ORM.Model;

namespace CSProject.Product.Api
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.CreateMap<ProductDto, Data.ORM.Model.Product>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<ProductDto, ProductVM>();
            });
        }
    }
}