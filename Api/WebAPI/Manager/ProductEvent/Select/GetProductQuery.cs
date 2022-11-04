using Core.Results;
using Entities;
using MediatR;
using System;

namespace WebAPI.Manager.ProductEvent.Select
{
    public partial class GetProductQuery : IRequest<SuccessDataResult<Product>>
    {
    }
    public partial class GetProductIDQuery : IRequest<SuccessDataResult<Product>>
    {
        public Guid ProductID { get; set; }
    }
}