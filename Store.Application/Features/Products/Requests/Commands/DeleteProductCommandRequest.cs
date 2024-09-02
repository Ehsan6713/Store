﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
