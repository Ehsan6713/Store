﻿using MediatR;
using Store.Application.DTOS.Order;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Requests.Commands
{
    public class UpdateOrderCommandRequest:IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
        public UpdateOrderDto UpdateOrderDto { get; set; }
    }
}
