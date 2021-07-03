//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSProject.Product.Services.Interfaces
//{
//    public interface IBaseService<TDto, TEntity>
//        where TDto : BaseDto
//        where TEntity : BaseEntity
//    {
//        void SaveChanges();
//        ReturnModel GetById(int id);
//        ReturnModel GetAll();
//        ReturnModel Insert(TDto entity);
//        ReturnModel Update(TDto entity);
//        ReturnModel Delete(int? id);
//    }
//}