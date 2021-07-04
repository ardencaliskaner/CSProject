using CSProject.Dto.DataDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<object> GetAllWithCategories();
    }
}
