using CSProject.Dto.DataDto;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services.Base;
using CSProject.Product.Services.Interfaces;

namespace CSProject.Product.Services
{
    public class ProductService : BaseService<ProductDto, Data.ORM.Model.Product>, IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
