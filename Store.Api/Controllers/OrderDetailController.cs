using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Order;
using Store.Application.DTOS.OrderDetail;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Features.OrderDetail.Requests.Queries;
using Store.Application.Features.Person.Handlers.Commands;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDetailDto>>> Get()
        {
            var respose = await mediator.Send(new GetOrderDetailListRequest());
            return Ok(respose);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDto>> Get(int id)
        {
            var respose = await mediator.Send(new GetOrderDetailDetailRequest() { Id = id });
            return Ok(respose);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateOrderDetailDto createOrderDetailDto)
        {
            var respose = await mediator.Send(new CreateOrderDetailCommandRequest() { CreateOrderDetailDto = createOrderDetailDto });
            return Ok(respose);
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateOrderDetailDto updateOrderDetailDto)
        {
            var respose = await mediator.Send(new UpdateOrderDetailCommandRequest() { UpdateOrderDetailDto = updateOrderDetailDto, Id = id });
            return Ok(respose);
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteOrderDetailCommandRequest() { Id = id });
            return Ok(response);
        }
    }
}
