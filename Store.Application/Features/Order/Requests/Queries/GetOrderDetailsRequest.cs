﻿using MediatR;
using Store.Application.DTOS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Requests.Queries
{
    public class GetOrderDetailsRequest:IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}