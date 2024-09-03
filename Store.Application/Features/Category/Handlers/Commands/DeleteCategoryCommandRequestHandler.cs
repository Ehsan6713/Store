using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Handlers.Commands
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandRequestHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.Get(request.Id);
            if (category == null)
            {
                throw new NotFoundException(nameof(Domain.Category), request.Id);
            }
            await categoryRepository.Delete(category);
        }
    }
}
