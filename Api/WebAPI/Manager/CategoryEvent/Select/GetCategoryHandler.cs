
using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.CategoryEvent.Select
{
    public partial class GetCategoryHandler : IRequestHandler<GetCategoryQuery, SuccessDataResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SuccessDataResult<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_unitOfWork.CategoryRepository.GetAll().Result);
        }
    }
    public partial class GetCategoryIDHandler : IRequestHandler<GetCategoryIDQuery, SuccessDataResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryIDHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<SuccessDataResult<Category>> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_unitOfWork.CategoryRepository.GetAll(x => x.ID == request.CategoryID).Result);
        }
    }
}