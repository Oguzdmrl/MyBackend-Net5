using Core.Results;
using Entities;
using MediatR;
using System;

namespace WebAPI.Manager.ProductEvent.Insert
{
    public partial class InsertProductCommandQuery : IRequest<SuccessDataResult<Product>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
    }
}