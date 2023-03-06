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
        public CategoryApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetCategoryQuery()));
        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] InsertCategoryCommandQuery param) => Ok(await _mediator.Send(param));
    }
}