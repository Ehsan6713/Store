using AutoMapper;
using MediatR;
using Store.Application.Features.Products.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest, int>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandRequestHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Domain.Product>(request.CreateProductDto);
            await productRepository.Add(product);
            return product.Id;
        }
    }
}
