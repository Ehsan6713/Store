using AutoMapper;
using MediatR;
using Store.Application.DTOS.Category;
using Store.Application.Features.Category.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Handlers.Queries
{
    public class GetCategoryDetailsRequestHandler : IRequestHandler<GetCategoryDetailsRequest, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryDetailsRequestHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.Get(request.Id);
            return mapper.Map<CategoryDto>(category);
        }
    }
}
