using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Order.Requests.Commands;
using Store.Application.Contracts.Persistence;
using Store.Application.Resposes;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Commands
{
    public class DeleteOrderCommandRequestHandler : IRequestHandler<DeleteOrderCommandRequest, BaseResponse<Unit>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public DeleteOrderCommandRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var baseCommandResponse = new BaseResponse<Unit>();
            var order = await orderRepository.Get(request.Id);
            if (order == null)
            {
                baseCommandResponse.Success = false;
                baseCommandResponse.Errors.Add("Object with this id not found");
            }
            else
            {
                await orderRepository.Delete(order);
            }
            baseCommandResponse.Data = Unit.Value;
            return baseCommandResponse;
        }
    }
}
