using Core.Results;
using DataAccess.Repo.UOW;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repo.Base.CommandRepo
{
    public partial class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity<Guid>
    {
        protected AppDBContext _context;
        private readonly UnitOfWork _uow;
        public CommandRepository(AppDBContext context)
        {
            _context = context;
            _uow = new(context);
        }

        public virtual async Task<SuccessDataResult<T>> Insert(T entity)
        {
            EntityEntry<T> result = await _context.Set<T>().AddAsync(entity);
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new SuccessDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Ekleme İşlemi Başarılı." });
        }
        public virtual async Task<SuccessDataResult<T>> Update(T entity)
        {
            EntityEntry<T> result = _context.Entry(entity);
            result.State = EntityState.Modified;
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new SuccessDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Güncelleme İşlemi Başarılı." });
        }
        public virtual async Task<SuccessDataResult<T>> Delete(T entity)
        {
            EntityEntry<T> result = _context.Set<T>().Remove(entity);
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new SuccessDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Silme İşlemi Başarılı." });
        }
    }
}