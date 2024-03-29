using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Queries
{
    public class GetAuthorListRequestHandler : IRequestHandler<GetAuthorListRequest, List<AuthorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorListRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<List<AuthorDto>> Handle(GetAuthorListRequest request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }
    }
}