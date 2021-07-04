using CSProject.Dto.DataDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<BasketDto>> GetAll();
    }
}
