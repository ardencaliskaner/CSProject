using CSProject.Dto.Base;
using CSProject.Dto.Model;
using CSProject.Basket.Data.ORM.Model;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services.Interfaces;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using Infrastructure.AutoMapper;
using System.Linq.Expressions;

namespace CSProject.Basket.Services.Base
{
    public abstract class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
             where TDto : BaseDto
             where TEntity : BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;


        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            InitializeMapping();
        }

        private void InitializeMapping()
        {
            try
            {
                AutoMapper.Mapper.Reset();
                var config = new MapperConfigurationExpression();

                config.CreateMap<TEntity, TDto>().IgnoreAllNonExisting();
                config.CreateMap<TDto, TEntity>().IgnoreAllNonExisting();

                AutoMapper.Mapper.Initialize(config);
                AutoMapper.Mapper.AssertConfigurationIsValid();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _baseRepository.SaveChanges();
        }

        public virtual TDto GetById(int Id)
        {
            var result = _baseRepository.FirstOrDefault(x => x.Id == Id);
            TDto model = AutoMapper.Mapper.Map<TDto>(result);
            return model;
        }

        public virtual List<TDto> GetAll()
        {
            var result = _baseRepository.GetAll();
            List<TDto> modelList = AutoMapper.Mapper.Map<List<TDto>>(result);
            return modelList;
        }

        public virtual TDto Insert(TDto model)
        {

            var entity = AutoMapper.Mapper.Map<TEntity>(model);
            var result = _baseRepository.Insert(entity);
            model = AutoMapper.Mapper.Map<TDto>(result);

            return model;
        }

        public virtual TDto Update(TDto model)
        {
            var entity = AutoMapper.Mapper.Map<TEntity>(model);
            var result = _baseRepository.Update(entity);
            model = AutoMapper.Mapper.Map<TDto>(result);
            return model;
        }

        public virtual bool Delete(int? id)
        {
            return _baseRepository.Delete(id);
        }
    }
}

