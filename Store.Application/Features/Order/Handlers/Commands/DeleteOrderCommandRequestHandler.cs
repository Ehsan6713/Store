using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Order.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Commands
{
    public class DeleteOrderCommandRequestHandler : IRequestHandler<DeleteOrderCommandRequest>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public DeleteOrderCommandRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.Get(request.Id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Domain.Order), request.Id);
            }
            await orderRepository.Delete(order);
        }
    }
}
