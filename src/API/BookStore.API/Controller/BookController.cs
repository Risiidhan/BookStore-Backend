using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Features.Book.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class BookController : ControllerBase
    {
         public readonly IMediator _mediator;

        public BookController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            var bookList = await _mediator.Send(new GetBookListRequest());
            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            var book = await _mediator.Send(new GetBookRequest{ Id = id });
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BookDto>> Post([FromBody] BookCreateDto bookCreateDto)
        {
            var book = new CreateBookCommand{ BookCreateDto = bookCreateDto };
            var result = await _mediator.Send(book);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BookDto>> Put([FromBody] BookUpdateDto bookUpdateDto)
        {
            var book = new UpdateBookCommand{ BookUpdateDto = bookUpdateDto };
            var result = await _mediator.Send(book);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BookDto>> Delete(int id)
        {
            var book = new DeleteBookCommand{ Id = id };
            var result = await _mediator.Send(book);
            return Ok(result);
        }

    }
}