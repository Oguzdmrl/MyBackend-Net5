using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Delete
{
    public partial class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public DeleteProductCommandHandler(IService<Product> service) => _service = service;
        public async Task<SuccessDataResult<Product>> Handle(DeleteProductCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Delete(new Product() { ID = request.ProductID }));
        }
    }
}