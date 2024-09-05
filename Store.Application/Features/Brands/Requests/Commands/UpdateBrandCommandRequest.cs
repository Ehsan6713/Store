using MediatR;
using Store.Application.DTOS.Brand;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Requests.Commands
{
    public class UpdateBrandCommandRequest:IRequest<BaseResponse<Unit>>
    {
        public UpdateBrandDto UpdateBrandDto { get; set; }
    }
}
