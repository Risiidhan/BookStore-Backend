using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.DTO.Author.Validator;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new AuthorCreateDtoValidator();
            var result = await validator.ValidateAsync(request.AuthorCreateDto);
            if(!result.IsValid)
            {
                res.Success = false;
                res.Message = "Creation Failed";
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var authorModel = _mapper.Map<domain.Models.Author>(request.AuthorCreateDto);
            var createdAuthor = await _authorRepository.AddAsync(authorModel);

            res.Id = createdAuthor.Id;
            res.Success = true;
            res.Message = "Created Successfully";
            return res;
        }
    }
}