using AutoMapper;
using CSProject.Dto.DataDto;
using CSProject.Basket.Data.ORM.Model;
using CSProject.Dto.ApiModel.Response;

namespace CSProject.Basket.Api
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.CreateMap<BasketDto, Data.ORM.Model.Basket>();
                cfg.CreateMap<Data.ORM.Model.Basket, BasketDto>();
                cfg.CreateMap<BasketProduct, BasketProductDto>();
                cfg.CreateMap<BasketProductDto, BasketProduct>();
                cfg.CreateMap<ProductDto, ProductStockResponseModel>();
            });
        }
    }
}