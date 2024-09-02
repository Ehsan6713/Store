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
    public class UpdateOrderCommandRequestHandler : IRequestHandler<UpdateOrderCommandRequest, Unit>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public UpdateOrderCommandRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.Get(request.Id);
            mapper.Map(request.OrderDto, order);
            await orderRepository.Update(order);
            return Unit.Value;
        }
    }
}
