﻿using MediatR;
using Store.Application.DTOS.OrderDetail;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Requests.Commands
{
    public class CreateOrderDetailCommandRequest:IRequest<BaseResponse<int>>
    {
        public CreateOrderDetailDto CreateOrderDetailDto { get; set; }
    }
}
