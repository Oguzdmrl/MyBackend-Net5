using DataAccess.Repo.Base.CommandRepo;
using DataAccess.Repo.Base.QueryableRepo;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repo.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;
        private Dictionary<Type, object> _repositories;


        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            _repositories = new();
        }

        public async Task<IQueryableRepository<T>> QueryableRepositories<T>() where T : BaseEntity<Guid>
        {
            if (_repositories is null) { _repositories = new(); }
            if (!Repositories.Keys.Contains(typeof(T)))
            {
                Repositories.Add(typeof(T), new QueryableRepository<T>(_context));
                return await Task.FromResult((IQueryableRepository<T>)new QueryableRepository<T>(_context));
            }
            return await Task.FromResult(Repositories[typeof(T)] as IQueryableRepository<T>);
        }

        public async Task<ICommandRepository<T>> CommandRepositories<T>() where T : BaseEntity<Guid>
        {
            if (_repositories is null) { _repositories = new(); }
            if (!Repositories.Keys.Contains(typeof(T)))
            {
                ICommandRepository<T> repo = new CommandRepository<T>(_context);
                Repositories.Add(typeof(T), repo);
                return await Task.FromResult(repo);
            }
            return await Task.FromResult(Repositories[typeof(T)] as ICommandRepository<T>);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async void Dispose()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}