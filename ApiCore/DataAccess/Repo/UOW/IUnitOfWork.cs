﻿using DataAccess.Repo.EfRepo;
using System.Threading.Tasks;

namespace DataAccess.Repo.UOW
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task CompleteAsync();
        void Dispose();
    }
}