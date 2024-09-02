﻿using MediatR;
using Store.Application.DTOS.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Requests.Commands
{
    public class UpdateOrderDetailCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public OrderDetailDto OrderDetailDto { get; set; }
    }
}