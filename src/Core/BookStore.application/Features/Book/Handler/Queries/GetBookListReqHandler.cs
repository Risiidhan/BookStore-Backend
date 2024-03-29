using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.Features.Book.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Book.Handler.Queries
{
    public class GetBookListReqHandler : IRequestHandler<GetBookListRequest, List<BookListDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListReqHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookListDto>> Handle(GetBookListRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBookDetailList();
            return _mapper.Map<List<BookListDto>>(books);
        }
    }
}