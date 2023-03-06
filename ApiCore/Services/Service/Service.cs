using Core.Results;
using DataAccess.Repo.UOW;
using Entities.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Service
{
    public class Service<T> : IService<T> where T : BaseEntity<Guid>
    {
        private readonly IUnitOfWork _uow;
        public Service(IUnitOfWork uow) => _uow = uow;

        public async Task<SuccessDataResult<T>> Delete(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Delete(entity));
        public async Task<SuccessDataResult<T>> Get(Guid ID) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.Get(ID));
        public async Task<SuccessDataResult<T>> GetAll() => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAll());
        public async Task<SuccessDataResult<T>> GetAll(Expression<Func<T, bool>> parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAll(parametre));
        public async Task<SuccessDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllInculude(Parametre));
        public async Task<SuccessDataResult<T>> Insert(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Insert(entity));
        public async Task<SuccessDataResult<T>> Update(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Update(entity));
    }
}