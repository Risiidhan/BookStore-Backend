using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Features.Author.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class AuthorController : ControllerBase
    {
        public readonly IMediator _mediator;

        public AuthorController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> Get()
        {
            var authorList = await _mediator.Send(new GetAuthorListRequest());
            return Ok(authorList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var author = await _mediator.Send(new GetAuthorRequest { Id = id });
            return Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorCreateDto authorCreateDto)
        {
            var author = new CreateAuthorCommand { AuthorCreateDto = authorCreateDto };
            var result = await _mediator.Send(author);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AuthorDto>> Put([FromBody] AuthorUpdateDto authorUpdateDto)
        {
            var author = new UpdateAuthorCommand { AuthorUpdateDto = authorUpdateDto };
            var result = await _mediator.Send(author);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            var author = new DeleteAuthorCommand { Id = id };
            var result = await _mediator.Send(author);
            return Ok(result);
        }

    }
}