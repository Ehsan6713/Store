﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOS.Category;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Features.Category.Requests.Queries;

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
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var categoriy = await mediator.Send(new GetCategoryDetailsRequest() { Id = id });
            return categoriy;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var response = await mediator.Send(new CreateCategoryCommandRequest() { CreateCategoryDto = createCategoryDto });
            return response;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var response = await mediator.Send(new UpdateCategoryCommandRequest() { UpdateCategoryDto = updateCategoryDto });
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await mediator.Send(new DeleteCategoryCommandRequest() { Id = id });
        }
    }
}