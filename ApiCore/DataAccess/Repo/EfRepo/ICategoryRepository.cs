using DataAccess.Repo.Base;
using Entities;

namespace DataAccess.Repo.EfRepo
{
    public interface ICategoryRepository : IRepository<Category> { }
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext dBContext) : base(dBContext) { }
    }
}