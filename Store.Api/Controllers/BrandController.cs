using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Brand;
using Store.Application.Features.Brands.Requests.Commands;
using Store.Application.Features.Brands.Requests.Queries;
using Store.Application.Features.Person.Handlers.Commands;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<BrandController>
        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> Get()
        {
            var lst = await mediator.Send(new GetBrandListRequest());
            return Ok(lst);
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> Get(int id)
        {
            var brand = await mediator.Send(new GetBrandDetailRequest() { Id = id });
            return Ok(brand);
        }

        // POST api/<BrandController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateBrandDto createBrandDto)
        {
            var result = await mediator.Send(new CreateBrandDtoCommandRequest() { CreateBrandDto = createBrandDto });
            return Ok(result);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateBrandDto updateBrandDto)
        {
            var response= await mediator.Send(new UpdateBrandCommandRequest() { UpdateBrandDto = updateBrandDto });
            return Ok(response);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteBrandCommandRequest() { Id = id });
            return Ok(response);
        }
    }
}
