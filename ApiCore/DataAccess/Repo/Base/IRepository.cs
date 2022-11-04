using Core.Results;
using Entities.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        Task<SuccessDataResult<TEntity>> Get(Guid ID);
        Task<SuccessDataResult<TEntity>> GetAll();
        Task<SuccessDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<SuccessDataResult<TEntity>> GetAllInculude(params Expression<Func<TEntity, object>>[] Parametre);
        Task<SuccessDataResult<TEntity>> Insert(TEntity entity);
        Task<SuccessDataResult<TEntity>> Update(TEntity entity);
        Task<SuccessDataResult<TEntity>> Delete(TEntity entity);
    }
}