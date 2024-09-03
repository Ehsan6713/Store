using AutoMapper;
using MediatR;
using Store.Application.DTOS.Brand.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Brands.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Handlers.Commands
{
    public class UpdateBrandCommandRequestHandler : IRequestHandler<UpdateBrandCommandRequest, Unit>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public UpdateBrandCommandRequestHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateBrandDtoValidator();
            var validationResult = validator.Validate(request.UpdateBrandDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var brand =await brandRepository.Get(request.UpdateBrandDto.Id);
            mapper.Map(request.UpdateBrandDto, brand);
            await brandRepository.Update(brand);
            return Unit.Value;
        }
    }
}
