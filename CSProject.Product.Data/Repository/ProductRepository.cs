using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.Repository.Base;
using CSProject.Product.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSProject.Product.Data.Repository
{
    public class ProductRepository : BaseRepository<ORM.Model.Product>, IProductRepository
    {
    }
}
