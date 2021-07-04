using AutoMapper;
using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Interfaces;
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

        public async Task<List<ProductResponseModel>> GetAll()
        {
            var productEntities = await _productRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<ProductResponseModel>>(productEntities);
        }

        public async Task<List<ProductResponseModel>> GetAllWithCategories()
        {
            var productEntities = await _productRepository.GetAllWithCategories().ConfigureAwait(false);
            return Mapper.Map<List<ProductResponseModel>>(productEntities);
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
