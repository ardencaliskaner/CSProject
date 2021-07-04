using AutoMapper;
using CSProject.Dto.DataDto;
using CSProject.Basket.Data.ORM.Model;

namespace CSProject.Basket.Api
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.CreateMap<BasketDto, Data.ORM.Model.Basket>();
            });
        }
    }
}