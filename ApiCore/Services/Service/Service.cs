using Core.Cache;
using Core.Cache.Enums;
using Core.Results;
using DataAccess.Repo.UOW;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Service
{
    public class Service<T> : IService<T> where T : BaseEntity<Guid>
    {
        private readonly IUnitOfWork _uow;
        public Service(IUnitOfWork uow) => _uow = uow;

        public async Task<SuccessDataResult<T>> Delete(T entity)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.Delete(entity);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> Get(Guid ID)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.Get(ID);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> GetAll()
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.GetAll();
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.GetAll(predicate);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.GetAllInculude(Parametre);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> Insert(T entity)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.Insert(entity);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
        public async Task<SuccessDataResult<T>> Update(T entity)
        {
            CacheEnums GetCacheEnumValue = (CacheEnums)Enum.Parse(typeof(CacheEnums), typeof(T).Name.ToString());
            SuccessDataResult<T> TList = await CacheHelperRepo.GetCache<T>(GetCacheEnumValue);
            if (TList.ListResponseModel is null)
            {
                var ListModel = await _uow.Repository<T>().Result.Update(entity);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<T>();
                CacheHelperRepo.SetCache(GetCacheEnumValue.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(TList);
        }
    }
}