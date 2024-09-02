﻿using MediatR;
using Store.Application.DTOS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Requests.Queries
{
    public class GetProductDetailRequest:IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}