﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail.Validations;
using Store.Application.Exceptions;
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
        private readonly IProductRepository productRepository;

        public UpdateOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper,IProductRepository productRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderDetailDtoValidator(productRepository);
            var validationResult = validator.Validate(request.UpdateOrderDetailDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var orderdetail = await orderDetailRepository.Get(request.Id);
            mapper.Map(request.UpdateOrderDetailDto, orderdetail);
            await orderDetailRepository.Update(orderdetail);
            return Unit.Value;
        }
    }
}
