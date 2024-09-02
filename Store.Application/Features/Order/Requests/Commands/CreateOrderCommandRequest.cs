using MediatR;
using Store.Application.DTOS.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Requests.Commands
{
    public class CreateOrderCommandRequest:IRequest<int>
    {
        public OrderDto OrderDto{ get; set; }
    }
}
