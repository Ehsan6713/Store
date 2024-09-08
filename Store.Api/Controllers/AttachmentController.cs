using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Order;
using Store.Application.Features.Attachment.Requests.Command;
using Store.Application.Features.Attachment.Requests.Queries;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Features.Person.Handlers.Commands;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttachmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public AttachmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<AttachmentController>
        [HttpGet]
        public async Task<ActionResult<List<AttachmentDto>>> Get()
        {
            var respose = await mediator.Send(new GetAttachmentListRequest());
            return respose;
        }

        // GET api/<AttachmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttachmentDto>> Get(int id)
        {
            var respose = await mediator.Send(new GetAttachmentDetailsRequst() { Id = id });
            return respose;
        }

        // POST api/<AttachmentController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreateAttachmentDto createAttachmentDto)
        {
            var respose = await mediator.Send(new CreateAttachmentCommandRequest() { CreateAttachmentDto = createAttachmentDto });
            return respose;
        }

        // PUT api/<AttachmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdateAttachmentDto updateAttachmentDto)
        {
            var respose = await mediator.Send(new UpdateAttachmentCommandRequest() { UpdateAttachmentDto = updateAttachmentDto });
            return respose;
        }

        // DELETE api/<AttachmentController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<Unit>> Delete(int id)
        {
            var respoonse = await mediator.Send(new DeleteAttachmentRequest() { Id = id });
            return respoonse;
        }
    }
}
