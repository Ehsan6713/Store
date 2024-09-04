using AutoMapper;
using MediatR;
using Store.Application.DTOS.Product.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Products.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<int>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var baseCommandResponse = new BaseResponse<int>();
            #region Validation
            var validator = new CreateProductDtoValidator();
            var validationResult = validator.Validate(request.CreateProductDto);
            if (validationResult.IsValid == false)
            {
                baseCommandResponse.Success = false;
                baseCommandResponse.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            #endregion
            if (baseCommandResponse.Success)
            {
                var product = mapper.Map<Domain.Product>(request.CreateProductDto);
                await productRepository.Add(product);
                baseCommandResponse.Data = product.Id;
            }
            return baseCommandResponse;
        }
    }
}
