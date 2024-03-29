using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorModel = _mapper.Map<domain.Models.Author>(request.AuthorCreateDto);
            var createdAuthor = await _authorRepository.AddAsync(authorModel);
            return _mapper.Map<AuthorDto>(createdAuthor);
        }
    }
}