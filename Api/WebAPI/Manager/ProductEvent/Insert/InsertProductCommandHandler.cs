using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Insert
{
    public partial class InsertProductCommandHandler : IRequestHandler<InsertProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsertProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SuccessDataResult<Product>> Handle(InsertProductCommandQuery request, CancellationToken cancellationToken)
        {
            Product _Product = new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryID = request.CategoryID
            };
            return await Task.FromResult(await _unitOfWork.ProductRepository.Insert(_Product));
        }
    }
}