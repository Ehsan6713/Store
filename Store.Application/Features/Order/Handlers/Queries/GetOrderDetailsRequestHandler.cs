using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Contracts.Persistence;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Queries
{
    public class GetOrderDetailsRequestHandler : IRequestHandler<GetOrderDetailsRequest, BaseResponse<OrderDto>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrderDetailsRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<OrderDto>> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<OrderDto>();
            try
            {
                var order = await orderRepository.Get(request.Id);
                response.Data = mapper.Map<OrderDto>(order);
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
