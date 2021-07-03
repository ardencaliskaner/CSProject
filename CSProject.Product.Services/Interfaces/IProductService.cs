using CSProject.Dto.DataDto;

namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService : IBaseService<ProductDto, Data.ORM.Model.Product>
    {
    }
}
