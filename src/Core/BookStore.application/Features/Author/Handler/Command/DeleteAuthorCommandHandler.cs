using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, AuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDto> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var deletedAuthor = await _authorRepository.DeleteAsync(request.Id);
            return _mapper.Map<AuthorDto>(deletedAuthor);
        }
    }
}