using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Features.Author.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
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
            var author = await _mediator.Send(new GetAuthorRequest{ Id = id });
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorCreateDto authorCreateDto)
        {
            var author = new CreateAuthorCommand{ AuthorCreateDto = authorCreateDto };
            var createdAuthor = await _mediator.Send(author);
            return Ok(createdAuthor);
        }

        [HttpPut]
        public async Task<ActionResult<AuthorDto>> Put([FromBody] AuthorUpdateDto authorUpdateDto)
        {
            var author = new UpdateAuthorCommand{ AuthorUpdateDto = authorUpdateDto };
            var updatedAuthor = await _mediator.Send(author);
            return Ok(updatedAuthor);
        }

        [HttpDelete]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            var author = new DeleteAuthorCommand{ Id = id };
            var deletedAuthor = await _mediator.Send(author);
            return Ok(deletedAuthor);
        }

    }
}