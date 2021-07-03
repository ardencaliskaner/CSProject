using CSProject.Product.Data.ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void SaveChanges();
        List<TEntity> GetAll();
        List<TEntity> GetAllWithQuery(Expression<Func<TEntity, bool>> lambda);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(int? id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lambda);
    }
}
