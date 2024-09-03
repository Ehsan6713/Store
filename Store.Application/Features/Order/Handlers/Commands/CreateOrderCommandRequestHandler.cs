using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order.Validations;
using Store.Application.DTOS.OrderDetail.Validations;
using Store.Application.Exceptions;
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
            #region Validation
            var validator = new CreateOrderDtoValidator();
            var validationResult = validator.Validate(request.CreateOrderDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var order = mapper.Map<Domain.Order>(request.CreateOrderDto);
            await orderRepository.Add(order);
            return order.Id;
        }
    }
}
