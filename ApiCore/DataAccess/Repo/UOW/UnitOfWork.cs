using DataAccess.Repo.EfRepo;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repo.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;

        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(context);
        }
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}