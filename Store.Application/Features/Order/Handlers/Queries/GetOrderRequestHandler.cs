﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.Order;
using Store.Application.Features.Order.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Handlers.Queries
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, List<OrderDto>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrderRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<List<OrderDto>> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var orders =await orderRepository.GetAll();
            return mapper.Map<List<OrderDto>>(orders);
        }
    }
}
