using MediatR;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommandRequest:IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
