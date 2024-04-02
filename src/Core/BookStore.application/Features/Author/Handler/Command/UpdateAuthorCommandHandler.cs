using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.DTO.Author.Validator;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthorUpdateDtoValidator(_authorRepository);
            var result = await validator.ValidateAsync(request.AuthorUpdateDto);
            if(!result.IsValid)
                throw new Exception();

            var authorModel = await _authorRepository.GetAsync(request.AuthorUpdateDto.Id);
            authorModel = _mapper.Map(request.AuthorUpdateDto, authorModel);
            var updatedAuthor = await _authorRepository.UpdateAsync(authorModel);
            return _mapper.Map<AuthorDto>(updatedAuthor);
        }
    }
}