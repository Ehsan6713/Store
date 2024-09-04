using AutoMapper;
using MediatR;
using Store.Application.DTOS.Brand;
using Store.Application.Features.Brands.Requests.Queries;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Handlers.Queries
{
    public class GetBrandDetailRequestHandler : IRequestHandler<GetBrandDetailRequest, BrandDto>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public GetBrandDetailRequestHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }

        public async Task<BrandDto> Handle(GetBrandDetailRequest request, CancellationToken cancellationToken)
        {
            var brand =await brandRepository.Get(request.Id);
            return mapper.Map<BrandDto>(brand);
        }
    }
}
