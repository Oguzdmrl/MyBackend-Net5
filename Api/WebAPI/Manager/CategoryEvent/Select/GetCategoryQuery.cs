using Core.Results;
using Entities;
using MediatR;
using System;

namespace WebAPI.Manager.CategoryEvent.Select
{
    public partial class GetCategoryQuery : IRequest<SuccessDataResult<Category>>
    {
    }
    public partial class GetCategoryIDQuery : IRequest<SuccessDataResult<Category>>
    {
        public Guid CategoryID { get; set; }
    }
}