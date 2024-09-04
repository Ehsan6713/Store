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
    public class GetBrandListRequestHandler : IRequestHandler<GetBrandListRequest, List<BrandDto>>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public GetBrandListRequestHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<List<BrandDto>> Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brands =await brandRepository.GetAll();
            return mapper.Map<List<BrandDto>>(brands);
        }
    }
}
