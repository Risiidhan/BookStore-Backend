using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.DTO.Author.Validator;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var validator = new AuthorUpdateDtoValidator(_authorRepository);
            var result = await validator.ValidateAsync(request.AuthorUpdateDto);
            if (!result.IsValid)
            {
                res.Success = false;
                res.Message = CommonMessage.UpdateFailed;
                res.Error = result.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var authorModel = await _authorRepository.GetAsync(request.AuthorUpdateDto.Id);
            authorModel = _mapper.Map(request.AuthorUpdateDto, authorModel);
            var updatedAuthor = await _authorRepository.UpdateAsync(authorModel!);

            res.Id = updatedAuthor.Id;
            res.Success = true;
            res.Message = CommonMessage.GetUpdatedSuccessfully(updatedAuthor.Name);
            res.Result = updatedAuthor;
            return res;
        }
    }
}