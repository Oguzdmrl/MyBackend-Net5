using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Update
{
    public partial class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<SuccessDataResult<Product>> Handle(UpdateProductCommandQuery request, CancellationToken cancellationToken)
        {
            var GetModel = await _unitOfWork.ProductRepository.GetAll(x => x.ID == request.ProductID);
            if (GetModel.ModelCount > 0)
            {
                GetModel.ListResponseModel.FirstOrDefault().Name = request.Name;
                GetModel.ListResponseModel.FirstOrDefault().Description = request.Description;
                GetModel.ListResponseModel.FirstOrDefault().CategoryID = request.CategoryID;
            }
            return await Task.FromResult(await _unitOfWork.ProductRepository.Update(GetModel.ListResponseModel.FirstOrDefault()));
        }
    }
}