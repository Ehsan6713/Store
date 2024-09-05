using AutoMapper;
using MediatR;
using Store.Application.DTOS.Category.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Category.Handlers.Commands
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest, BaseResponse<Unit>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            #region Validation
            var validator = new UpdateCategoryDtoValidator();
            var validationResult = validator.Validate(request.UpdateCategoryDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var category = await categoryRepository.Get(request.UpdateCategoryDto.Id);
                mapper.Map(request.UpdateCategoryDto, category);
                await categoryRepository.Update(category);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
