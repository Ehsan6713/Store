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

namespace Store.Application.Features.Brands.Handlers.Commands
{
    public class CreateBrandDtoCommandRequestHandler : IRequestHandler<CreateBrandDtoCommandRequest, int>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public CreateBrandDtoCommandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateBrandDtoCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateBrandDtoValidator();
            var validationResult = validator.Validate(request.CreateBrandDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var brand = mapper.Map<Brand>(request.CreateBrandDto);
            await brandRepository.Add(brand);
            return brand.Id;
        }
    }
}
