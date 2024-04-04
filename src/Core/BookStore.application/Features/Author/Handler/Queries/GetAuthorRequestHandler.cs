using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Queries
{
    public class GetAuthorRequestHandler : IRequestHandler<GetAuthorRequest, AuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;

        }
        public async Task<AuthorDto> Handle(GetAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsync(request.Id);
              if(author == null)
                throw new Exception();
              
            return _mapper.Map<AuthorDto>(author);
        }
    }
}