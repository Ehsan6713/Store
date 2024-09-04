﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.OrderDetail.Validations;
using Store.Application.DTOS.Person.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Persistence;

namespace Store.Application.Features.OrderDetail.Handlers.Commands
{
    public class CreateOrderDetailCommandRequestHandler : IRequestHandler<CreateOrderDetailCommandRequest, int>
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateOrderDetailCommandRequestHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper,IProductRepository productRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public async Task<int> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateOrderDetailDtoValidator(productRepository);
            
            var validationResult =await validator.ValidateAsync(request.CreateOrderDetailDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var orderDetail = mapper.Map<Domain.OrderDetail>(request.CreateOrderDetailDto);
            await orderDetailRepository.Add(orderDetail);
            return orderDetail.Id;

        }
    }
}
