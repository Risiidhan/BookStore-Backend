using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.DTO.Category;
using BookStore.application.Response;
using MediatR;

namespace BookStore.application.Features.Category.Request.Command
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CategoryCreateDto CategoryCreateDto { get; set; } = null!;
    }
}