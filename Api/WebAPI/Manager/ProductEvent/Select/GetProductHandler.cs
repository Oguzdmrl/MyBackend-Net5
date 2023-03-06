using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Select
{
    public partial class GetProductHandler : IRequestHandler<GetProductQuery, SuccessDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductHandler(IService<Product> service) => _service = service;

        public async Task<SuccessDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAllInculude(x=>x.Category));
        }
    }
    public partial class GetProductIDHandler : IRequestHandler<GetProductIDQuery, SuccessDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductIDHandler(IService<Product> service) => _service = service;
        public async Task<SuccessDataResult<Product>> Handle(GetProductIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.ProductID));
        }
    }
}