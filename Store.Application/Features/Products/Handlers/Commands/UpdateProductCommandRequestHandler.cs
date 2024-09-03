using AutoMapper;
using MediatR;
using Store.Application.DTOS.Product.Validations;
using Store.Application.Features.Products.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateProductDtoValidator();
            var validationResult = validator.Validate(request.UpdateProductDto);
            if (validationResult.IsValid == false)
                throw new Exception("Not Valid Object");
            #endregion

            var product = await productRepository.Get(request.Id);
            if (request.UpdateProductDto != null)
            {
                mapper.Map(request.UpdateProductDto, product);
                await productRepository.Update(product);
            }
            else if (request.ChangeProductStockDto != null)
            {
                mapper.Map(request.ChangeProductStockDto, product);
                await productRepository.ChangeProductStock(product, request.ChangeProductStockDto.Stock);
            }
            return Unit.Value;
        }
    }
}
