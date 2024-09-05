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
using Store.Application.Resposes;

namespace Store.Application.Features.Brands.Handlers.Commands
{
    public class DeleteBrandCommandRequestHandler : IRequestHandler<DeleteBrandCommandRequest, BaseResponse<Unit>>
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public DeleteBrandCommandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            var brand = await brandRepository.Get(request.Id);
            if (brand == null)
            {
                respons.Success = false;
                respons.Errors.Add($"Not Found Id {request.Id}");
                respons.Message = $"Not Found {request.Id}";
            }
            else
            {
                await brandRepository.Delete(brand);
                respons.Data = Unit.Value;
            }
            return respons;


        }
    }
}
