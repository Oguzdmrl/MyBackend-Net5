using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.CategoryEvent.Insert
{
    public partial class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommandQuery, SuccessDataResult<Category>>
    {
        private readonly Service<Category> _service;
        public InsertCategoryCommandHandler(Service<Category> service) => _service = service;
        public async Task<SuccessDataResult<Category>> Handle(InsertCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            Category _Category = new()
            {
                Name = request.Name
            };
            return await Task.FromResult(await _service.Insert(_Category));
        }
    }
}