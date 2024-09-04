using AutoMapper;
using MediatR;
using Store.Application.DTOS.Product;
using Store.Application.Features.Products.Requests.Queries;
using Store.Application.Contracts.Persistence;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<ProductDto>> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();
            try
            {
                var product = await productRepository.Get(request.Id);
                response.Data = mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
