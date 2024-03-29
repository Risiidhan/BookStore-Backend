using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.DTO.Author;
using MediatR;

namespace BookStore.application.Features.Author.Request.Queries
{
    public class GetAuthorRequest : IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }
}