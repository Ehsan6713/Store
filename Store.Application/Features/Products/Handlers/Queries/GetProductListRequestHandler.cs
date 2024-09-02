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
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAll();
            return mapper.Map<List<ProductDto>>(products);
        }
    }
}
