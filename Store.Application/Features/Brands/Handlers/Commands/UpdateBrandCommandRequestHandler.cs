using AutoMapper;
using MediatR;
using Store.Application.DTOS.Brand.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Brands.Requests.Commands;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Brands.Handlers.Commands
{
    public class UpdateBrandCommandRequestHandler : IRequestHandler<UpdateBrandCommandRequest, BaseResponse<Unit>>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public UpdateBrandCommandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            #region Validation
            var validator = new UpdateBrandDtoValidator();
            var validationResult = validator.Validate(request.UpdateBrandDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var brand = await brandRepository.Get(request.UpdateBrandDto.Id);
                mapper.Map(request.UpdateBrandDto, brand);
                await brandRepository.Update(brand);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
