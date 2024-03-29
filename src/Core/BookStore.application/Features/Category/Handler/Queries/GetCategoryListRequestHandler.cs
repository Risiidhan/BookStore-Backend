using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.Features.Category.Request.Queries;
using BookStore.application.Interface;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryListRequestHandler(ICategoryRepository category , IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;
            
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}