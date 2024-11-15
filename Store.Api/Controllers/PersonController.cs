﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Order;
using Store.Application.DTOS.Person;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Features.Person.Handlers.Commands;
using Store.Application.Features.Person.Requests.Commands;
using Store.Application.Features.Person.Requests.Queries;
using Store.Application.Resposes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            var respose = await mediator.Send(new GetPersonListRequest());
            return Ok(respose);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var respose = await mediator.Send(new GetPersonDetailsRequest() { Id = id });
            return Ok(respose);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] CreatePersonDto createPersonDto)
        {
            var respose = await mediator.Send(new CreatePersonCommandRequest() { CreatePersonDto = createPersonDto });
            return Ok(respose);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Put(int id, [FromBody] UpdatePersonDto updatePersonDto)
        {
            var respose = await mediator.Send(new UpdatePersonCommandRequest() { UpdatePersonDto = updatePersonDto });
            return Ok(respose);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<Unit>>> Delete(int id)
        {
            var response = await mediator.Send(new DeletePersonCommandRequst() { Id = id });
            return Ok(response);
        }
    }
}
