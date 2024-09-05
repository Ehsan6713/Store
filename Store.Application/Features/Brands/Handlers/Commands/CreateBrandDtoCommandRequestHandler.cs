using AutoMapper;
using MediatR;
using Store.Application.DTOS.Brand.Validations;
using Store.Application.DTOS.Category.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Brands.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Brands.Handlers.Commands
{
    public class CreateBrandDtoCommandRequestHandler : IRequestHandler<CreateBrandDtoCommandRequest, BaseResponse<int>>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public CreateBrandDtoCommandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateBrandDtoCommandRequest request, CancellationToken cancellationToken)
        {
            var respons=new BaseResponse<int>();
            #region Validation
            var validator = new CreateBrandDtoValidator();
            var validationResult = validator.Validate(request.CreateBrandDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var brand = mapper.Map<Brand>(request.CreateBrandDto);
                await brandRepository.Add(brand);
                respons.Data = brand.Id;
            }
            return respons;
        }
    }
}
