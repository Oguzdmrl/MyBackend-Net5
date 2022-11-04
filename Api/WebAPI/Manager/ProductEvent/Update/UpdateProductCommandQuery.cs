using Core.Results;
using Entities;
using MediatR;
using System;

namespace WebAPI.Manager.ProductEvent.Update
{
    public partial class UpdateProductCommandQuery : IRequest<SuccessDataResult<Product>>
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}