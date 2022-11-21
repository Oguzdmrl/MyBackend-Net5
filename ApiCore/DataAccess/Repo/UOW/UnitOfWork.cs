using DataAccess.Repo.Base;
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
        public async Task<IRepository<T>> Repository<T>() where T : BaseEntity<Guid>
        {
            if (_repositories is null) { _repositories = new(); }
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return await Task.FromResult(Repositories[typeof(T)] as IRepository<T>);
            }
            IRepository<T> repo = new GenericRepository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return await Task.FromResult(repo);
        }
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        public async void Dispose()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}