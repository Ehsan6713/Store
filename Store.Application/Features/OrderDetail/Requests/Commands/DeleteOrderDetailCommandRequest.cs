using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.OrderDetail.Requests.Commands
{
    public class DeleteOrderDetailCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
