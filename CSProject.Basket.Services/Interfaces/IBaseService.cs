using CSProject.Dto.Base;
using CSProject.Dto.Model;
using CSProject.Basket.Data.ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CSProject.Basket.Services.Interfaces
{
    public interface IBaseService<TDto, TEntity>
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        void SaveChanges();
        DtoResponseModel GetById(int id);
        DtoResponseModel GetAll();
        DtoResponseModel Insert(TDto entity);
        DtoResponseModel Update(TDto entity);
        DtoResponseModel Delete(int? id);
    }
}