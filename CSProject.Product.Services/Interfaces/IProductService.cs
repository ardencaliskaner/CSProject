using System.Threading.Tasks;

namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService
    {
        Task<object> GetAllWithCategories();
    }
}
