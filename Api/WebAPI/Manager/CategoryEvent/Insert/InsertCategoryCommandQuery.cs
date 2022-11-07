using Core.Results;
using Entities;
using MediatR;

namespace WebAPI.Manager.CategoryEvent.Insert
{
    public partial class InsertCategoryCommandQuery : IRequest<SuccessDataResult<Category>>
    {
        public string Name { get; set; }
    }
}