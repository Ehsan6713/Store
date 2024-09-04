using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Product;
using Store.Application.Features.Products.Requests.Commands;
using Store.Application.Features.Products.Requests.Queries;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<Product>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ProductDto>>>> Get()
        {
            var response =await mediator.Send(new GetProductListRequest());
            return response;
        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ProductDto>>> Get(int id)
        {
            var response = await mediator.Send(new GetProductDetailRequest() { Id=id});
            return response;
        }

        // POST api/<Product>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateProductDto createProductDto)
        {
            var response = await mediator.Send(new CreateProductCommandRequest() { CreateProductDto= createProductDto });
            return response;
        }

        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var response = await mediator.Send(new UpdateProductCommandRequest() {Id=id,UpdateProductDto= updateProductDto });
            return response;
        }

        // DELETE api/<Product>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteProductCommandRequest() { Id = id});
            return response;
        }
    }
}
