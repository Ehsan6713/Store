using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Order.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Commands
{
    public class UpdateOrderCommandRequestHandler : IRequestHandler<UpdateOrderCommandRequest, BaseResponse<Unit>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public UpdateOrderCommandRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var baseCommandResponse = new BaseResponse<Unit>();
            #region Validation
            var validator = new UpdateOrderDtoValidator();
            var validationResult = validator.Validate(request.UpdateOrderDto);
            if (validationResult.IsValid == false)
            {
                baseCommandResponse.Success = false;
                baseCommandResponse.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            #endregion
            if (baseCommandResponse.Success)
            {
                var order = await orderRepository.Get(request.Id);
                mapper.Map(request.UpdateOrderDto, order);
                await orderRepository.Update(order);
            }
            baseCommandResponse.Data = Unit.Value;
            return baseCommandResponse;
        }
    }
}
