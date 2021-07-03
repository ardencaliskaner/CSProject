using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Interfaces;

namespace CSProject.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void SeedData()
        {
            _productRepository.SeedData();
        }


        public int GetByProductId(string productname)
        {
            var product = _productRepository.FirstOrDefault(x => x.Name == productname);

            var productId = product?.ID ?? 1;


            return productId;
        }
    }
}
