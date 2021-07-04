using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<object> GetAllWithCategories();
    }
}
