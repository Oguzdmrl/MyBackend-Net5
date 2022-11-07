using DataAccess.Repo.UOW;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Manager.CategoryEvent.Insert;
using WebAPI.Manager.CategoryEvent.Select;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;
        public CategoryApiController(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetCategoryQuery()));
        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] InsertCategoryCommandQuery param)
        {
            var result = await _mediator.Send(param);
            await _uow.CompleteAsync();
            return Ok(result);
        }
    }
}