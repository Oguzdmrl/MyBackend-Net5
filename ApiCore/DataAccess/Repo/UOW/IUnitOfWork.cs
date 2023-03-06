using DataAccess.Repo.Base.CommandRepo;
using DataAccess.Repo.Base.QueryableRepo;
using Entities.Base;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repo.UOW
{
    public interface IUnitOfWork
    {
        Task<IQueryableRepository<T>> QueryableRepositories<T>() where T : BaseEntity<Guid>;
        Task<ICommandRepository<T>> CommandRepositories<T>() where T : BaseEntity<Guid>;

        Task SaveChangesAsync();
        void Dispose();
    }
}