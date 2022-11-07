using Core.Results;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base
{
    public partial class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        private SuccessDataResult<TEntity> _Response;
        private DbSet<TEntity> Table;
        protected AppDBContext _context;
        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }
        public virtual async Task<SuccessDataResult<TEntity>> Get(Guid ID) => await Task.FromResult(new SuccessDataResult<TEntity>() { ResponseModel = await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.ID == ID), Status = true, Message = "Listeleme İşlemi Başarılı." });
        public virtual async Task<SuccessDataResult<TEntity>> GetAll()
        {
            return await Task.FromResult(new SuccessDataResult<TEntity>()
            {
                ListResponseModel = await _context.Set<TEntity>().ToListAsync(),
                Status = true,
                Message = "Listeleme İşlemi Başarılı."
            });
        }

        public virtual async Task<SuccessDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            Table = _context.Set<TEntity>();
            _Response = new();
            IEnumerable<TEntity> Model = null;

            Model = Table.Where(predicate).ToList();
            if (Model is null)
            {
                _Response.Message = "Veri Bulunamadı";
                return await Task.FromResult(_Response);
            }
            return await Task.FromResult(new SuccessDataResult<TEntity>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Veriler Başarılı Şekilde Çekildi [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }

    public async Task<SuccessDataResult<TEntity>> GetAllInculude(params Expression<Func<TEntity, object>>[] Parametre)
        {
            Table = _context.Set<TEntity>();
            IEnumerable<TEntity> Model = null;
            _Response = new();
            Parametre.ToList().ForEach(x => Table.Include(x).Load());
            Model = Table;
            if (Model is null)
            {
                _Response.Message = "Veri Bulunamadı";
                return await Task.FromResult(_Response);
            }
            return await Task.FromResult(new SuccessDataResult<TEntity>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Veriler Başarılı Şekilde Çekildi [{Model.ToList().Count}] Adet Veri Çekildi"
            });

        }
        public virtual async Task<SuccessDataResult<TEntity>> Insert(TEntity entity) => await Task.FromResult(new SuccessDataResult<TEntity>() { ResponseModel = _context.Set<TEntity>().AddAsync(entity).Result.Entity, Status = true, Message = "Ekleme İşlemi Başarılı." });

        public virtual async Task<SuccessDataResult<TEntity>> Update(TEntity entity)
        {
            var result = _context.Entry(entity);
            result.State = EntityState.Modified;
            return await Task.FromResult(new SuccessDataResult<TEntity>() { ResponseModel = result.Entity, Status = true, Message = "Güncelleme İşlemi Başarılı." });
        }
        public virtual async Task<SuccessDataResult<TEntity>> Delete(TEntity entity) => await Task.FromResult(new SuccessDataResult<TEntity>() { ResponseModel = _context.Set<TEntity>().Remove(entity).Entity, Status = true, Message = "Silme İşlemi Başarılı." });
    }
}
