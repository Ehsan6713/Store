using AutoMapper;
using MediatR;
using Store.Application.DTOS.Product;
using Store.Application.Features.Products.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.Get(request.Id);
            return mapper.Map<ProductDto>(product);
        }
    }
}
