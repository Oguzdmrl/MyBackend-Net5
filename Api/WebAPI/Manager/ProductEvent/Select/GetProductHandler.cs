using Core.Cache;
using Core.Cache.Enums;
using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
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
            SuccessDataResult<Product> ProductList = await CacheHelperRepo.GetCache<Product>(CacheEnums.GetProduct);
            if (!ProductList.Status)
            {
                var ListModel = await _unitOfWork.ProductRepository.GetAllInculude(x => x.Category);
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<Product>();
                CacheHelperRepo.SetCache(CacheEnums.GetProduct.ToString(), Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(ProductList);
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