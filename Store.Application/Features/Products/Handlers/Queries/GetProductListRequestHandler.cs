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
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, BaseResponse<List<ProductDto>>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<List<ProductDto>>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<ProductDto>>();
            try
            {
                var products = await productRepository.GetAll();
                response.Data = mapper.Map<List<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }
    }
}
