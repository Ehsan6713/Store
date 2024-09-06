using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Category;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Features.Category.Requests.Queries;
using Store.Application.Features.Person.Handlers.Commands;
using Store.Application.Resposes;
using Store.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var categories = await mediator.Send(new GetCategoryListRequest());
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var categoriy = await mediator.Send(new GetCategoryDetailsRequest() { Id = id });
            return Ok(categoriy);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var response = await mediator.Send(new CreateCategoryCommandRequest() { CreateCategoryDto = createCategoryDto });
            return Ok(response);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var response = await mediator.Send(new UpdateCategoryCommandRequest() { UpdateCategoryDto = updateCategoryDto });
            return Ok(response);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteCategoryCommandRequest() { Id = id });
            return Ok(response);
        }
    }
}
