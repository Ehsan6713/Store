using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail.Validations;
using Store.Application.DTOS.Person.Validations;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Handlers.Commands
{
    public class CreateOrderDetailCommandRequestHandler : IRequestHandler<CreateOrderDetailCommandRequest, int>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public CreateOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateOrderDetailDtoValidator();
            var validationResult = validator.Validate(request.CreateOrderDetailDto);
            if (validationResult.IsValid == false)
                throw new Exception("Not Valid Object");
            #endregion
            var orderDetail = mapper.Map<Domain.OrderDetail>(request.CreateOrderDetailDto);
            await orderDetailRepository.Add(orderDetail);
            return orderDetail.Id;

        }
    }
}
