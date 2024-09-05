using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Category.Handlers.Commands
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest, BaseResponse<Unit>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandRequestHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            var category = await categoryRepository.Get(request.Id);
            if (category == null)
            {
                respons.Success = false;
                respons.Errors.Add($"Not Found Id {request.Id}");
                respons.Message = "Not Found";
            }
            else
            {
                await categoryRepository.Delete(category);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
