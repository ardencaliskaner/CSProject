using AutoMapper.Configuration;
using CSProject.Dto.DataDto;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Interfaces;
using Infrastructure.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeMapping();
        }

        private void InitializeMapping()
        {
            try
            {
                AutoMapper.Mapper.Reset();
                var config = new MapperConfigurationExpression();

                config.CreateMap<Data.ORM.Model.Product, ProductDto>();
                config.CreateMap<List<Data.ORM.Model.Product>, List<ProductDto>>();


                config.CreateMap<ProductDto, Data.ORM.Model.Product>();
                config.CreateMap<List<ProductDto>, List<Data.ORM.Model.Product>>();

                AutoMapper.Mapper.Initialize(config);
                AutoMapper.Mapper.AssertConfigurationIsValid();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var productEntities = await _productRepository.GetAll();

            var productDtos = AutoMapper.Mapper.Map<List<ProductDto>>(productEntities);

            return productDtos;
        }



        public async Task<object> GetAllWithCategories()
        {
            return await _productRepository.GetAllWithCategories();
        }
    }
}
