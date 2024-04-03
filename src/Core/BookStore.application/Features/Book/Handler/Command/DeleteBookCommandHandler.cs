using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Command
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var bookTodelete = await _bookRepository.GetAsync(request.Id);
            if (bookTodelete == null)
            {
                res.Success = false;
                res.Message = "Delete Failed";
            }
            var deletedBook = await _bookRepository.DeleteAsync(request.Id);

            res.Id = deletedBook.Id;
            res.Success = true;
            res.Message = "Deleted Successfully";
            return res;
        }
    }
}