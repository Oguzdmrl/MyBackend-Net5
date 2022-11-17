
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

namespace WebAPI.Manager.CategoryEvent.Select
{
    public partial class GetCategoryHandler : IRequestHandler<GetCategoryQuery, SuccessDataResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SuccessDataResult<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            SuccessDataResult<Category> CategoryList = await CacheHelperRepo.GetCache<Category>(CacheEnums.GetCategory);
           
            if (!CategoryList.Status)
            {
               var ListModel = await _unitOfWork.CategoryRepository.GetAll();
                var Model = ListModel.ListResponseModel != null ? ListModel.ListResponseModel.ToList() : new List<Category>();
                CacheHelperRepo.SetCache(CacheEnums.GetCategory.ToString(),Model);
                return await Task.FromResult(ListModel);
            }
            return await Task.FromResult(CategoryList);

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