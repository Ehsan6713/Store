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
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.Get(request.Id);
            await productRepository.Delete(product);
        }
    }
}
