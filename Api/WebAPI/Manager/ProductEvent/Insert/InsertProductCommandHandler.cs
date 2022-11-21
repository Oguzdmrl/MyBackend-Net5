using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Insert
{
    public partial class InsertProductCommandHandler : IRequestHandler<InsertProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly Service<Product> _service;
        public InsertProductCommandHandler(Service<Product> service) => _service = service;
        public async Task<SuccessDataResult<Product>> Handle(InsertProductCommandQuery request, CancellationToken cancellationToken)
        {
            Product _Product = new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryID = request.CategoryID
            };
            return await Task.FromResult(await _service.Insert(_Product));
        }
    }
}