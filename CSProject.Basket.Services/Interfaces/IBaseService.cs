using CSProject.Dto.Base;
using CSProject.Dto.Model;
using CSProject.Basket.Data.ORM.Model;
using System.Collections.Generic;

namespace CSProject.Basket.Services.Interfaces
{
    public interface IBaseService<TDto, TEntity>
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        void SaveChanges();
        TDto GetById(int id);
        List<TDto> GetAll();
        TDto Insert(TDto entity);
        TDto Update(TDto entity);
        bool Delete(int? id);
    }
}