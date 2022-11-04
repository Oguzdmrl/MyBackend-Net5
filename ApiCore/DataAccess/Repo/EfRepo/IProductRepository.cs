using DataAccess.Repo.Base;
using Entities;

namespace DataAccess.Repo.EfRepo
{
    public interface IProductRepository : IRepository<Product> { }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext dBContext) : base(dBContext) { }
    }
}