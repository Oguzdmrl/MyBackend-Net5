using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.CategoryEvent.Select
{
    public partial class GetCategoryHandler : IRequestHandler<GetCategoryQuery, SuccessDataResult<Category>>
    {
        private readonly Service<Category> _service;
        public GetCategoryHandler(Service<Category> service) => _service = service;
        public async Task<SuccessDataResult<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll());
        }
    }
    public partial class GetCategoryIDHandler : IRequestHandler<GetCategoryIDQuery, SuccessDataResult<Category>>
    {
        private readonly Service<Category> _service;
        public GetCategoryIDHandler(Service<Category> service) => _service = service;
        public async Task<SuccessDataResult<Category>> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.CategoryID));
        }
    }
}