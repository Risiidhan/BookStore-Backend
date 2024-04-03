using AutoMapper;
using BookStore.application.DTO.Category;
using BookStore.application.Features.Category.Request.Command;
using BookStore.application.Interface;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Category.Handler.Command
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandHandler(ICategoryRepository category, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = category;

        }
        public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseCommandResponse();
            var categoryTodelete = await _categoryRepository.GetAsync(request.Id);
            if (categoryTodelete == null)
            {
                res.Success = false;
                res.Message = "Delete Failed";
            }
            var deletedCategory = await _categoryRepository.DeleteAsync(request.Id);
            res.Id = deletedCategory.Id;
            res.Success = true;
            res.Message = "Deleted Successfully";
            return res;
        }
    }
}