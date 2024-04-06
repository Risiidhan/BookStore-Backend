using AutoMapper;
using BookStore.application.DTO.Author;
using BookStore.application.Features.Author.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Author.Handler.Command
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();

            var authorTodelete = await _authorRepository.GetAsync(request.Id);
            if(authorTodelete == null)
            {
                res.Success = false;
                res.Message = CommonMessage.DeleteFailed;
            }

            var authorModel = _mapper.Map<domain.Models.Author>(authorTodelete);
            var deletedAuthor = await _authorRepository.DeleteAsync(authorModel);

            res.Id = deletedAuthor.Id;
            res.Success = true;
            res.Message = CommonMessage.GetDeletedSuccessfully(deletedAuthor.Name);
            return res;
        }
    }
}