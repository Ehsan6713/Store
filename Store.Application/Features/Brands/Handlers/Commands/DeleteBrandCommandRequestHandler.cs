using AutoMapper;
using MediatR;
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
    public class DeleteBrandCommandRequestHandler : IRequestHandler<DeleteBrandCommandRequest>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public DeleteBrandCommandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand =await brandRepository.Get(request.Id);
            if (brand == null)
            {
                throw new NotFoundException(nameof(Domain.Brand), request.Id);
            }
            await brandRepository.Delete(brand);


        }
    }
}
