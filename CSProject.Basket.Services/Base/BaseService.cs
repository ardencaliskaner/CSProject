﻿using CSProject.Dto.Base;
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

        public virtual DtoResponseModel GetById(int Id)
        {
            DtoResponseModel dtoResponseModel = new DtoResponseModel();

            try
            {
                var result = _baseRepository.FirstOrDefault(x => x.Id == Id);
                if (result != null)
                {
                    TDto model = AutoMapper.Mapper.Map<TDto>(result);

                    dtoResponseModel.IsSuccess = true;
                    dtoResponseModel.Message = Message.Success;
                    dtoResponseModel.Data = model;

                    return dtoResponseModel;
                }
                else
                {
                    dtoResponseModel.IsSuccess = false;
                    dtoResponseModel.Message = Message.NoItem;

                    return dtoResponseModel;
                }
            }
            catch (Exception ex)
            {
                dtoResponseModel.IsSuccess = false;
                dtoResponseModel.Message = Message.Error;

                return dtoResponseModel;
            }
        }

        public virtual DtoResponseModel GetAll()
        {
            DtoResponseModel dtoResponseModel = new DtoResponseModel();

            try
            {
                var result = _baseRepository.GetAll();
                List<TDto> modelList = AutoMapper.Mapper.Map<List<TDto>>(result);

                dtoResponseModel.IsSuccess = true;
                dtoResponseModel.Message = Message.Success;
                dtoResponseModel.Data = modelList;

                return dtoResponseModel;
            }
            catch (Exception ex)
            {
                dtoResponseModel.IsSuccess = false;
                dtoResponseModel.Message = Message.Error;

                return dtoResponseModel;
            }
        }

        public virtual DtoResponseModel Insert(TDto model)
        {
            DtoResponseModel dtoResponseModel = new DtoResponseModel();
            try
            {
                if (model != null)
                {
                    var entity = AutoMapper.Mapper.Map<TEntity>(model);
                    var result = _baseRepository.Insert(entity);
                    model = AutoMapper.Mapper.Map<TDto>(result);

                    dtoResponseModel.IsSuccess = true;
                    dtoResponseModel.Message = Message.Success;
                    dtoResponseModel.Data = model;

                    return dtoResponseModel;
                }
                else
                {
                    dtoResponseModel.IsSuccess = false;
                    dtoResponseModel.Message = Message.Empty;

                    return dtoResponseModel;
                }
            }
            catch (Exception ex)
            {
                dtoResponseModel.IsSuccess = false;
                dtoResponseModel.Message = Message.Error;

                return dtoResponseModel;
            }
        }

        public virtual DtoResponseModel Update(TDto model)
        {
            DtoResponseModel dtoResponseModel = new DtoResponseModel();
            try
            {
                if (model != null)
                {
                    var entity = AutoMapper.Mapper.Map<TEntity>(model);
                    var result = _baseRepository.Update(entity);
                    model = AutoMapper.Mapper.Map<TDto>(result);

                    dtoResponseModel.IsSuccess = true;
                    dtoResponseModel.Message = Message.Success;
                    dtoResponseModel.Data = model;

                    return dtoResponseModel;
                }
                else
                {
                    dtoResponseModel.IsSuccess = false;
                    dtoResponseModel.Message = Message.Empty;

                    return dtoResponseModel;
                }
            }
            catch (Exception ex)
            {
                dtoResponseModel.IsSuccess = false;
                dtoResponseModel.Message = Message.Error;

                return dtoResponseModel;
            }
        }

        public virtual DtoResponseModel Delete(int? Id)
        {
            DtoResponseModel dtoResponseModel = new DtoResponseModel();
            try
            {
                if (Id != null)
                {
                    dtoResponseModel.IsSuccess = _baseRepository.Delete(Id); ;
                    dtoResponseModel.Message = _baseRepository.Delete(Id) ? Message.Success : Message.Error;

                    return dtoResponseModel;
                }
                else
                {
                    dtoResponseModel.IsSuccess = false;
                    dtoResponseModel.Message = Message.Empty;

                    return dtoResponseModel;
                }
            }
            catch (Exception ex)
            {
                dtoResponseModel.IsSuccess = false;
                dtoResponseModel.Message = Message.Empty;

                return dtoResponseModel;
            }
        }
    }
}
