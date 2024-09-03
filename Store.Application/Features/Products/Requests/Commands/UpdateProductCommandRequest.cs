using MediatR;
using Store.Application.DTOS.Product;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommandRequest:IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
        public UpdateProductDto UpdateProductDto{ get; set; }
        public ChangeProductStockDto ChangeProductStockDto { get; set; }
    }
}
