using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Select
{
    public partial class GetProductHandler : IRequestHandler<GetProductQuery, SuccessDataResult<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SuccessDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_unitOfWork.ProductRepository.GetAllInculude(x => x.Category).Result);
        }
    }
    public partial class GetProductIDHandler : IRequestHandler<GetProductIDQuery, SuccessDataResult<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductIDHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<SuccessDataResult<Product>> Handle(GetProductIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_unitOfWork.ProductRepository.GetAll(x => x.ID == request.ProductID).Result);
        }
    }
}