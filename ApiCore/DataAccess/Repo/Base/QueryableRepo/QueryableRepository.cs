using Core.Results;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base.QueryableRepo
{
    public partial class QueryableRepository<T> : IQueryableRepository<T> where T : BaseEntity<Guid>
    {
        private SuccessDataResult<T> _response;
        private DbSet<T> Table;

        protected AppDBContext _context;
        public QueryableRepository(AppDBContext context)
        {
            _context = context;
            Table ??= _context.Set<T>();
            _response = new(false, "Veri bulunamadı");
        }

        public virtual async Task<SuccessDataResult<T>> Get(Guid ID)
        {
            return await Task.FromResult(new SuccessDataResult<T>() { ResponseModel = await _context.Set<T>().FirstOrDefaultAsync(p => p.ID == ID), Status = true, Message = "Listeleme İşlemi Başarılı." });
        }
        public virtual async Task<SuccessDataResult<T>> GetAll()
        {
            IEnumerable<T> Model = await _context.Set<T>().ToListAsync();

            if (Model is null) return await Task.FromResult(_response);

            return await Task.FromResult(new SuccessDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                Message = "Listeleme İşlemi Başarılı.",
                ModelCount = Model.ToList().Count,
            });
        }
        public virtual async Task<SuccessDataResult<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> Model = await Table.Where(predicate).ToListAsync();

            if (Model is null) return await Task.FromResult(_response);

            return await Task.FromResult(new SuccessDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Listeleme İşlemi Başarılı : [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }
        public async Task<SuccessDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre)
        {
            Parametre.ToList().ForEach(x => Table.Include(x).LoadAsync());
            IEnumerable<T> Model = Table;

            if (Model is null) return await Task.FromResult(_response);

            return await Task.FromResult(new SuccessDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Listeleme İşlemi Başarılı : [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }
    }
}