using DataAccess.Repo.UOW;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Manager.ProductEvent.Delete;
using WebAPI.Manager.ProductEvent.Insert;
using WebAPI.Manager.ProductEvent.Select;
using WebAPI.Manager.ProductEvent.Update;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;
        public ProductApiController(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetProductQuery()));
        //[HttpGet]
        //public async Task<IActionResult> GetIDProduct([FromBody] GetProductIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] InsertProductCommandQuery param)
        {
            var result = await _mediator.Send(param);
            await _uow.CompleteAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandQuery param)
        {
            var result = await _mediator.Send(param);
            await _uow.CompleteAsync();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandQuery param)
        {
            var result = await _mediator.Send(param);
            await _uow.CompleteAsync();
            return Ok(result);
        }
    }
}