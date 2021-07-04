using AutoMapper;
using AutoMapper.Configuration;
using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
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

        public async Task<ProductStockResponseModel> GetProduct(ProductStockRequestModel productStockRequestModel)
        {
            var productEntity = await _productRepository.GetProduct(productStockRequestModel.ProductId).ConfigureAwait(false);

            return Mapper.Map<ProductStockResponseModel>(productEntity);
        }

        public async Task<List<ProductResponseModel>> GetProductsWithId(List<ProductRequestModel> productRequestModels)
        {
            var productIds = productRequestModels.Select(x => x.Id).ToList();
            return await _productRepository.GetProductsWithId(productIds).ConfigureAwait(false);
        }
    }
}
