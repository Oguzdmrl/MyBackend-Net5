using Core.Results;
using Entities;
using MediatR;
using System;

namespace WebAPI.Manager.ProductEvent.Delete
{
    public partial class DeleteProductCommandQuery : IRequest<SuccessDataResult<Product>>
    {
        public Guid ProductID { get; set; }
    }
}