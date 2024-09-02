using AutoMapper;
using MediatR;
using Store.Application.Features.Order.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Commands
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, int>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public CreateOrderCommandRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Domain.Order>(request.OrderDto);
            await orderRepository.Add(order);
            return order.Id;
        }
    }
}
