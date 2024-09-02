﻿using MediatR;
using Store.Application.DTOS.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Requests.Queries
{
    public class GetOrderDetailRequest:IRequest<List<OrderDetailDto>>
    {
    }
}
