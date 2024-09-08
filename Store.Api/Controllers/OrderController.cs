using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Order;
using Store.Application.Features.Order.Requests.Commands;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<Order>
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            var response =await mediator.Send(new GetOrderListRequest());
            return Ok(response);
        }

        // GET api/<Order>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<OrderDto>>> Get(int id)
        {
            var response = await mediator.Send(new GetOrderDetailsRequest() { Id=id});
            return Ok(response);
        }

        // POST api/<Order>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateOrderDto createOrderDto)
        {
            var response = await mediator.Send(new CreateOrderCommandRequest() { CreateOrderDto= createOrderDto });
            return Ok(response);
        }

        // PUT api/<Order>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            var response = await mediator.Send(new UpdateOrderCommandRequest() {Id=id,UpdateOrderDto= updateOrderDto });
            return Ok(response);
        }

        // DELETE api/<Order>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteOrderCommandRequest() { Id = id});
            return Ok(response);
        }
    }
}
