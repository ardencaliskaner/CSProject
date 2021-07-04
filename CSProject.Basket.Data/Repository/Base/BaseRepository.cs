using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.ORM.Model;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSProject.Basket.Data.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected CSProjectBasketContext db;
        protected DbSet<TEntity> dbcontext;
        public BaseRepository()
        {
            db = new CSProjectBasketContext();
            dbcontext = db.Set<TEntity>();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return dbcontext.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }

        public virtual List<TEntity> GetAllWithQuery(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => x.IsDeleted == false).Where(lambda).ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity != null)
            {
                entity.AddDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = false;
                entity.IsActive = true;
                dbcontext.Add(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = dbcontext.Find(entity.Id);
                entity.AddDate = _entity.AddDate;
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = _entity.IsDeleted;
                db.Entry(_entity).CurrentValues.SetValues(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual bool Delete(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                SaveChanges();
                return true;
            }
            else
                return false;
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => !x.IsDeleted).FirstOrDefault(lambda);
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(db);
        }
    }
}