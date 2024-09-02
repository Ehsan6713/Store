using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Order.Requests.Commands
{
    public class DeleteOrderCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
