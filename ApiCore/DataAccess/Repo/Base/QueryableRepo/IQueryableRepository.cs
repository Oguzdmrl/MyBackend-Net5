using Core.Results;
using Entities.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base.QueryableRepo
{
    public interface IQueryableRepository<T> where T : BaseEntity<Guid>
    {
        Task<SuccessDataResult<T>> Get(Guid ID);
        Task<SuccessDataResult<T>> GetAll();
        Task<SuccessDataResult<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<SuccessDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre);
    }
}