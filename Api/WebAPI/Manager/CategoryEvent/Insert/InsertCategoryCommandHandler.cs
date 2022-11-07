using Core.Results;
using DataAccess.Repo.UOW;
using Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.CategoryEvent.Insert
{
    public partial class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommandQuery, SuccessDataResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsertCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SuccessDataResult<Category>> Handle(InsertCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            Category _Category = new()
            {
                Name = request.Name
            };
            return await Task.FromResult(await _unitOfWork.CategoryRepository.Insert(_Category));
        }
    }
}