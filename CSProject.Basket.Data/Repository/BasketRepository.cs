using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.Repository.Base;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSProject.Basket.Data.Repository
{
    public class BasketRepository : BaseRepository<ORM.Model.Basket>, IBasketRepository
    {
    }
}
