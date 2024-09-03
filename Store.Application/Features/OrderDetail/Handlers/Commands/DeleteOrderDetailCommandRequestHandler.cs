using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Handlers.Commands
{
    public class DeleteOrderDetailCommandRequestHandler : IRequestHandler<DeleteOrderDetailCommandRequest>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public DeleteOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var orderDetail =await orderDetailRepository.Get(request.Id);
            if (orderDetail == null)
            {
                throw new NotFoundException(nameof(Domain.OrderDetail), request.Id);
            }
            await orderDetailRepository.Delete(orderDetail);
        }
    }
}
