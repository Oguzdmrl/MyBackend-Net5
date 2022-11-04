using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Delete
{
    public partial class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<SuccessDataResult<Product>> Handle(DeleteProductCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _unitOfWork.ProductRepository.Delete(new Product() { ID = request.ProductID }));
        }
    }
}