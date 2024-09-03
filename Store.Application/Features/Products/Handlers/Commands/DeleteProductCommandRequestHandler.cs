using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Products.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponse<Unit>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var baseCommandResponse = new BaseResponse<Unit>();
            var product = await productRepository.Get(request.Id);
            if (product == null)
            {
                baseCommandResponse.Success = false;
                baseCommandResponse.Errors.Add("Object with this id not found");
            }
            else
            {
                await productRepository.Delete(product);
            }
            baseCommandResponse.Data = Unit.Value;
            return baseCommandResponse;
        }
    }
}
