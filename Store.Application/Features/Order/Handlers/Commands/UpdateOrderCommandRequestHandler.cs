using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order.Validations;
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
            #region Validation
            var validator = new UpdateOrderDtoValidator();
            var validationResult = validator.Validate(request.UpdateOrderDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var order = await orderRepository.Get(request.Id);
            mapper.Map(request.UpdateOrderDto, order);
            await orderRepository.Update(order);
            return Unit.Value;
        }
    }
}
