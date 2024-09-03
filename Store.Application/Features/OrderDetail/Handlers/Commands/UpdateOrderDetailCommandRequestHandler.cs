using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail.Validations;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Handlers.Commands
{
    public class UpdateOrderDetailCommandRequestHandler : IRequestHandler<UpdateOrderDetailCommandRequest, Unit>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public UpdateOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderDetailDtoValidator();
            var validationResult = validator.Validate(request.UpdateOrderDetailDto);
            if (validationResult.IsValid == false)
                throw new Exception("Not Valid Object");
            #endregion
            var orderdetail = await orderDetailRepository.Get(request.Id);
            mapper.Map(request.UpdateOrderDetailDto, orderdetail);
            await orderDetailRepository.Update(orderdetail);
            return Unit.Value;
        }
    }
}
