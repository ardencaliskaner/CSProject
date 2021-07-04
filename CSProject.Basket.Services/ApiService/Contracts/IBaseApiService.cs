using System.Threading.Tasks;

namespace CSProject.Basket.Services.ApiService.Contracts
{
    public interface IBaseApiService<TInput, TOutput>
          where TInput : class
          where TOutput : class
    {
        Task<TOutput> GetDataFromApi(TInput reqModel, string url);
    }
}
