using AutoMapper;
using CSProject.Dto.ApiModel.Response;
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
                cfg.CreateMap<Data.ORM.Model.Product, ProductDto>();
                cfg.CreateMap<ProductStockResponseModel, Data.ORM.Model.Product>();
                cfg.CreateMap<Data.ORM.Model.Product, ProductStockResponseModel>();

                cfg.CreateMap<CategoryDto, Category>();
            });
        }
    }
}