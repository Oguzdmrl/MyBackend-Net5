using Core.Results;
using Entities.Base;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base.CommandRepo
{
    public interface ICommandRepository<T> where T : BaseEntity<Guid>
    {
        Task<SuccessDataResult<T>> Insert(T entity);
        Task<SuccessDataResult<T>> Update(T entity);
        Task<SuccessDataResult<T>> Delete(T entity);
    }
}