using AutoMapper;
using AutoMapper.Configuration;
using CSProject.Dto.DataDto;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Interfaces;
using Infrastructure.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSProject.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<ProductDto>> GetAll()
        {
            var productEntities = await _productRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<ProductDto>>(productEntities);
        }

        public async Task<List<ProductDto>> GetAllWithCategories()
        {
            var productEntities = await _productRepository.GetAllWithCategories().ConfigureAwait(false);
            var mapped = Mapper.Map<List<ProductDto>>(productEntities);

            return mapped;
        }
    }
}
