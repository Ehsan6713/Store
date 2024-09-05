using AutoMapper;
using MediatR;
using Store.Application.DTOS.Category.Validations;
using Store.Application.DTOS.Order.Validations;
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
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponse<int>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<int>();
            #region Validation
            var validator = new CreateCategoryDtoValidator();
            var validationResult = validator.Validate(request.CreateCategoryDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var category = mapper.Map<Store.Domain.Category>(request.CreateCategoryDto);
                await categoryRepository.Add(category);
                respons.Data = category.Id;
            }
            return respons;
        }
    }
}
