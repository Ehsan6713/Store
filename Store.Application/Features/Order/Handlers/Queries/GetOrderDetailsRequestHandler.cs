using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Queries
{
    public class GetOrderDetailsRequestHandler : IRequestHandler<GetOrderDetailsRequest, OrderDto>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrderDetailsRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.Get(request.Id);
            return mapper.Map<OrderDto>(order);
        }
    }
}
