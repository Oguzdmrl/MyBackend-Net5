using DataAccess.Repo.Base;
using Entities.Base;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repo.UOW
{
    public interface IUnitOfWork
    {
        Task<IRepository<T>> Repository<T>() where T : BaseEntity<Guid>;
        Task CompleteAsync();
        void Dispose();
    }
}