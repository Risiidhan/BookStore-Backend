using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.DTO.Book;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Book.Request.Command
{
    public class CreateBookCommand : IRequest <BaseCommandResponse>
    {
        public BookCreateDto BookCreateDto { get; set; } = null!;
    }
}