using CSProject.Dto.DataDto;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Interfaces;
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
        }


        public async Task<object> GetAllWithCategories()
        {
            return await _productRepository.GetAllWithCategories();
        }
    }
}
