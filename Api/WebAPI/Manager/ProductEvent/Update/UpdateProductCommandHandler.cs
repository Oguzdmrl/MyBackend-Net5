using Core.Results;
using Entities;
using MediatR;
using Services.Service;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Manager.ProductEvent.Update
{
    public partial class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandQuery, SuccessDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public UpdateProductCommandHandler(IService<Product> service) => _service = service;
        public async Task<SuccessDataResult<Product>> Handle(UpdateProductCommandQuery request, CancellationToken cancellationToken)
        {
            var GetModel = await _service.GetAll(x => x.ID == request.ProductID);
            if (GetModel.ModelCount > 0)
            {
                GetModel.ListResponseModel.FirstOrDefault().Name = request.Name;
                GetModel.ListResponseModel.FirstOrDefault().Description = request.Description;
                GetModel.ListResponseModel.FirstOrDefault().CategoryID = request.CategoryID;
            }
            return await Task.FromResult(await _service.Update(GetModel.ListResponseModel.FirstOrDefault()));
        }
    }
}