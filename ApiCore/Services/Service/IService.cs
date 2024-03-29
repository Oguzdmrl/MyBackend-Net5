﻿using Core.Results;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Service
{
    public interface IService<T>
    {
        Task<SuccessDataResult<T>> Get(Guid ID);
        Task<SuccessDataResult<T>> GetAll();
        Task<SuccessDataResult<T>> GetAll(Expression<Func<T, bool>> parametre);
        Task<SuccessDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre);
        Task<SuccessDataResult<T>> Insert(T entity);
        Task<SuccessDataResult<T>> Update(T entity);
        Task<SuccessDataResult<T>> Delete(T entity);
    }
}