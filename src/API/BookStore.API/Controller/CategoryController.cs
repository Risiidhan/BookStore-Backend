using BookStore.application.DTO.Category;
using BookStore.application.Features.Category.Request.Command;
using BookStore.application.Features.Category.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
         public readonly IMediator _mediator;

        public CategoryController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var categoryList = await _mediator.Send(new GetCategoryListRequest());
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryRequest{ Id = id });
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var category = new CreateCategoryCommand{ CategoryCreateDto = categoryCreateDto };
            await _mediator.Send(category);
            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Put([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var category = new UpdateCategoryCommand{ CategoryUpdateDto = categoryUpdateDto };
            await _mediator.Send(category);
            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryDto>> Delete(int id)
        {
            var category = new DeleteCategoryCommand{ Id = id };
            await _mediator.Send(category);
            return Ok(category);
        }

    }
}