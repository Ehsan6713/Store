using MediatR;
using Store.Application.DTOS.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Brands.Requests.Commands
{
    public class CreateBrandDtoCommandRequest : IRequest<int>
    {
        public CreateBrandDto CreateBrandDto { get; set; }
    }
}
